using MMD.Domain.Model;
using MMD.Domain.UpdateModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMD.Domain.Services
{
    public interface IAuthorService
    {
        Author CreateAuthor(Author author);
        Author GetAuthor(int id);
        Author UpdateAuthor(UpdateAuthor updateAuthor);
        void DeleteAuthor(int id);
    }
}
