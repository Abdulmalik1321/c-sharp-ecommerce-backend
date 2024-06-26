using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendTeamwork.Entities;

namespace BackendTeamwork.Abstractions
{
    public interface ICategoryRepository
    {

        public IEnumerable<Category> FindMany(int limit, int offset);
        public Task<Category?> FindOne(Guid id);
        public Task<Category> CreateOne(Category newCategory);

        public Task<Category> UpdateOne(Category updateCategory);

        public Task<Category> DeleteOne(Category deletedCategory);

    }
}