using Mert.CinemaBlog.Data.Contexts;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mert.CinemaBlog.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
       private readonly DataContext _dataContext;

        public UnitOfWork()
        {
            _dataContext = new DataContext();
        }

        private readonly ArticleRepository _articleRepository;
        private readonly CategoryRepository _categoryRepository;    
        private readonly CommentRepository _commentRepository;
        private readonly UserRepository _userRepository;    

        public IArticleRepository ArticleRepository => _articleRepository ?? new ArticleRepository(_dataContext);

        public IUserRepository UserRepository => _userRepository ?? new UserRepository(_dataContext);

        public ICommentRepository CommentRepository => _commentRepository ?? new CommentRepository(_dataContext);

        public ICategoryRepository CategoryRepository => _categoryRepository ?? new CategoryRepository(_dataContext);

        public void SaveChanges()
        {
            _dataContext.SaveChanges(); 
        }
    }
}
