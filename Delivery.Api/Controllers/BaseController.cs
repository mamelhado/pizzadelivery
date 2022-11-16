using AutoMapper;
using Delivery.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.Api.Controllers
{
    public class BaseController<TEntity, TInputModel, TOutputModel, TUpdateModel> : ControllerBase
    where TEntity : class
    where TInputModel : class
    where TOutputModel : class
    where TUpdateModel : class
    {

        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IBaseService<TEntity> _baseService;
        public BaseController(ILogger logger, IBaseService<TEntity> baseService, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _baseService = baseService;
        }

        [HttpGet]
        [Route("")]
        public IAsyncEnumerable<TEntity> GetAsync(CancellationToken cancellationToken = default)
        {
            var entities = _baseService.GetAsync(cancellationToken);//Talvez um projection??

             return entities;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<TOutputModel>> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            if (id == 0)
                return BadRequest($"Error in request, set a valid id value. id seted in request {id}");

            var result = _mapper.Map<TOutputModel>(await _baseService.GetByIdAsync(id, cancellationToken));
            
            if(result is null)
                return NotFound($"Not found object with id :{id}");

            return Ok(result);
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<TOutputModel>> PostAsync([FromBody] TInputModel inputModel, CancellationToken cancellationToken = default) 
        {
            if (inputModel is null)
                return BadRequest($"Error in request, the body is null");

            var obj = await _baseService.AddOrUpdateAsync(_mapper.Map<TEntity>(inputModel),cancellationToken);

            if (obj is null)
                return UnprocessableEntity();

            return Created("Success, entity created!", _mapper.Map<TOutputModel>(obj));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<TOutputModel>> PutAsync([FromBody] TUpdateModel updateModel, int id, CancellationToken cancellationToken = default)
        {
            if (updateModel is null)
                return BadRequest($"Error in request, the body is null");

            var obj = await _baseService.AddOrUpdateAsync(_mapper.Map<TEntity>(updateModel), cancellationToken);

            if (obj is null)
                return UnprocessableEntity();


            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<TOutputModel>> DeleteAsync(int id, CancellationToken cancellationToken = default) 
        {
            if (id == 0)
                return BadRequest($"Error in request, set a valid id value. id seted in request {id}");

            await _baseService.DeleteAsync(id,cancellationToken);

            return Accepted($"Entity with id : {id} has successful deleted!");
        }

        [Route("/error")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult HandleError() 
        {
            return Problem();
        }

        [Route("/error-development")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult HandleErrorDevelopment([FromServices] IHostEnvironment hostEnvironment)
        {
            if (!hostEnvironment.IsDevelopment())
            {
                return NotFound();
            }

            var exceptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>()!;

            return Problem(detail: exceptionHandlerFeature.Error.StackTrace,
                           title: exceptionHandlerFeature.Error.Message);
        }
    }
}