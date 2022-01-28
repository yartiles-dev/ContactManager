using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ContactManager.Authorization;
using ContactManager.Helpers;
using ContactManager.Models.Contacts;
using ContactManager.Services;

namespace ContactManager.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ContactsController : ControllerBase
    {
        private IContactService _contactService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public ContactsController(
            IContactService contactService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _contactService = contactService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var contacts = _contactService.GetAll();
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var contact = _contactService.GetById(id);
            return Ok(contact);
        }
        
        [HttpPost]
        public IActionResult Create(CreateRequest model)
        {
            var contact = _contactService.Create(model);
            return CreatedAtAction("GetById", new { id = contact.Id }, contact);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateRequest model)
        {
            _contactService.Update(id, model);
            return Ok(new { message = "Contact updated successfully" });
        }

        [AllowCubanAdministrators]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _contactService.Delete(id);
            return Ok(new { message = "Contact deleted successfully" });
        }
    }
}
