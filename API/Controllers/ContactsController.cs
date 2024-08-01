﻿using API.Middlewares.Exceptions;
using API.Validation;
using Application.Services;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        /// <summary>
        /// Lista os contatos cadastrados no sistema. Permite a opção de filtro de contatos pela localização através do DDD.
        /// </summary>
        /// <param name="DDD" example="11">Opção de filtro por região pelo DDD.</param>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IList<ContactResponseModel>>> ListAllContacts([FromQuery] string? DDD)
        {
            if (DDD is not null) return await _contactService.FilterByDdd(DDD);

            return Ok(await _contactService.ListAll());
        }

        /// <summary>
        /// Busca um contato pelo id informado.
        /// </summary>
        /// <param name="id" example="1">Id do contato buscado.</param>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ContactResponseModel>> GetContact(int id)
        {
            var contact = await _contactService.GetById(id)!;

            if (contact is null)
            {
                NotFoundException.Throw("001", "Contato não encontrado.");
            }

            return contact!;
        }

        /// <summary>
        /// Cadastra um novo contato no sistema.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ContactResponseModel>> CreateContact(ContactRequestModel contact)
        {
            //incluir validacao
            ContactValidator validator = new();
            validator.IsValid(contact);

            var response = await _contactService.Create(contact);

            return CreatedAtAction(nameof(GetContact), new { id = response.Id }, response);
        }

        /// <summary>
        /// Atualiza um cadastro no sistema.
        /// </summary>
        /// <param name="id" example="1">Id do contato a ser atualizado.</param>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ContactResponseModel>> PutContact(int id, ContactRequestModel contact)
        {
            //incluir validacao
            ContactValidator validator = new();
            validator.IsValid(contact);

            var response = await _contactService.Update(id, contact);

            if (response is null)
            {
                NotFoundException.Throw("001", "Contato não encontrado.");
            }

            return Ok(response);
        }

        /// <summary>
        /// Remove um contato do sistema.
        /// </summary>
        /// <param name="id" example="1">Id do contato a ser removido.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteContact(int id)
        {
            await _contactService.Delete(id);

            return NoContent();
        }

    }
}