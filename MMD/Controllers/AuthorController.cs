using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMD.Domain.Model;
using MMD.Domain.Services;
using MMD.Domain.UpdateModel;

namespace MMD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost]
        public Author CreateAuthor(Author author)
        {
            return _authorService.CreateAuthor(author);
        }

        [HttpGet]

        public Author GetAuthor(int id)
        {
           return _authorService.GetAuthor(id);
        }

        [HttpPut]

        public Author UpdateAuthor(UpdateAuthor author)
        {
           return _authorService.UpdateAuthor(author);
        }

        [HttpDelete]
        public void DeleteAuthor (int id)
        {
            _authorService.DeleteAuthor(id);
        }

    }
}