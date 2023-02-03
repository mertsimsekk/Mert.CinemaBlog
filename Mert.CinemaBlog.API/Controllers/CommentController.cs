using Mert.CinemaBlog.API.Controllers.Base;
using Mert.CinemaBlog.Model.CommentDtos;
using Mert.CinemaBlog.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mert.CinemaBlog.API.Controllers
{
    
    public class CommentController : BaseController
    {

        [HttpGet]
        [Route("GetListNonDeletedByArticleId")]
        public List<CommentDto> GetListNonDeletedByArticleId(int articleId)
        {
            CommentManager commentManager = new();
            return commentManager.GetListNonDeletedByArticleId(articleId);
        }

        [HttpGet]
        [Route("GetListByArticleId")]
        public List<CommentDto> GetListByArticleId(int articleId)
        {
            CommentManager commentManager = new();
            return commentManager.GetListByArticleId(articleId);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Add")]
        public void Add([FromBody] AddCommentDto addCommentDto)
        {
            CommentManager commentManager = new();
            commentManager.Add(addCommentDto);
        }

        [HttpGet]
        [Route("Delete")]
        public void Delete(int commentId)
        {
            CommentManager commentManager = new();
            commentManager.Delete(commentId);
        }
    }
}
