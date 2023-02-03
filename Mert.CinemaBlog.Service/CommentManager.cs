using Mert.CinemaBlog.Data.Repositories;
using Mert.CinemaBlog.Entities;
using Mert.CinemaBlog.Model.CommentDtos;
using Mert.CinemaBlog.Service.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mert.CinemaBlog.Service
{
    public class CommentManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommentManager()
        {
            _unitOfWork = new UnitOfWork();
        }
        private IEnumerable<CommentDto> GetAllQuery(int articleId)
        {
            return (from c in _unitOfWork.CommentRepository.GetAll(c => c.ArticleId == articleId)
                    join u in _unitOfWork.UserRepository.GetAll() on c.UserId equals u.Id
                    select new CommentDto
                    {
                        Id = c.Id,
                        Content = c.Content,
                        CreatedDate = c.CreatedDate,
                        IsDeleted = c.IsDeleted,
                        User = u.ToDto()
                    }).AsEnumerable<CommentDto>();
        }


        public List<CommentDto> GetListNonDeletedByArticleId(int articleId)
        {
            var commentDtos = GetAllQuery(articleId).Where(c => !c.IsDeleted).ToList();
            return commentDtos;
        }

        public List<CommentDto> GetListByArticleId(int articleId)
        {
            var commentDtos = GetAllQuery(articleId).ToList();
            return commentDtos;
        }

        public void Add(AddCommentDto addCommentDto)
        {
            try
            {
                _unitOfWork.CommentRepository.Add(addCommentDto.ToEntity());
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Delete(int commentId)
        {
            try
            {
                Comment comment = _unitOfWork.CommentRepository.Get(c => c.Id == commentId);
                comment.IsDeleted = true;
                comment.DeletedBy = "Yılmaz Simsek";
                comment.DeletedDate = DateTime.Now;
                _unitOfWork.CommentRepository.Update(comment);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
