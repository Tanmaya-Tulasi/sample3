using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerRepository customerRepository, 
            IProductRepository productRepository,
            IMapper mapper)
        {
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Customer>))]
        public IActionResult GetCustomer()
        {
            var owners = _mapper.Map<List<CustomerDto>>(_customerRepository.GetCustomer());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(owners);
        }

        [HttpGet("{customerId}")]
        [ProducesResponseType(200, Type = typeof(Customer))]
        [ProducesResponseType(400)]
        public IActionResult GetCustomer(int customerId)
        {
            if (!_customerRepository.OwnerExists(customerId))
                return NotFound();

            var owner = _mapper.Map<CustomerDto>(_customerRepository.GetCustomer(customerId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(owner);
        }

        [HttpGet("{customerId}/order")]
        [ProducesResponseType(200, Type = typeof(Customer))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonByOwner(int customerId)
        {
            if (!_customerRepository.OwnerExists(customerId))
            {
                return NotFound();
            }

            var owner = _mapper.Map<List<OrderDto>>(
                _customerRepository.GetPokemonByOwner(customerId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(owner);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCustomer([FromQuery] int productId, [FromBody] CustomerDto ownerCreate)
        {
            if (ownerCreate == null)
                return BadRequest(ModelState);

            var owners = _customerRepository.GetCustomer()
                .Where(c => c.CustomerName.Trim().ToUpper() == ownerCreate.CustomerName.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (owners != null)
            {
                ModelState.AddModelError("", "Owner already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ownerMap = _mapper.Map<Customer>(ownerCreate);

            ownerMap.Product = _productRepository.GetProduct(productId);

            if (!_customerRepository.CreateCustomer(ownerMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{customerId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateOwner(int customerId, [FromBody] CustomerDto updatedOwner)
        {
            if (updatedOwner == null)
                return BadRequest(ModelState);

            if (customerId != updatedOwner.Id)
                return BadRequest(ModelState);

            if (!_customerRepository.OwnerExists(customerId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var ownerMap = _mapper.Map<Customer>(updatedOwner);

            if (!_customerRepository.UpdateCustomer(ownerMap))
            {
                ModelState.AddModelError("", "Something went wrong updating owner");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{customerId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteOwner(int customerId)
        {
            if (!_customerRepository.OwnerExists(customerId))
            {
                return NotFound();
            }

            var ownerToDelete = _customerRepository.GetCustomer(customerId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_customerRepository.DeleteCustomer(ownerToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting owner");
            }

            return NoContent();
        }
    }
}
