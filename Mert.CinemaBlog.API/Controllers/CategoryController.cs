using Mert.CinemaBlog.API.Controllers.Base;
using Mert.CinemaBlog.Model.CategoryDtos;
using Mert.CinemaBlog.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mert.CinemaBlog.API.Controllers
{
    
    public class CategoryController : BaseController
    {
        [HttpGet]
        [Route("Get")]
        public CategoryDto Get(int categoryId)
        {
            CategoryManager categoryManager = new();
            return categoryManager.Get(categoryId);
        }


        [HttpGet]
        [Route("GetAll")]
        public List<CategoryDto> GetAll()
        {
            CategoryManager categoryManager = new();
            return categoryManager.GetAll();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetAllNonDeleted")]
        public List<CategoryDto> GetAllNonDeleted()
        {
            CategoryManager categoryManager = new();
            return categoryManager.GetAllNonDeleted();
        }

        [HttpPost]
        [Route("Add")]
        public void Add([FromBody] AddCategoryDto addCategoryDto)
        {
            CategoryManager categoryManager = new();
            categoryManager.Add(addCategoryDto);
        }

        [HttpPut]
        [Route("Update")]
        public void Update([FromBody] UpdateCategoryDto updateCategoryDto, int categoryId)
        {
            CategoryManager categoryManager = new();
            categoryManager.Update(updateCategoryDto, categoryId);
        }

        [HttpGet]
        [Route("Delete")]
        public void Delete(int categoryId)
        {
            CategoryManager categoryManager = new();
            categoryManager.Delete(categoryId);
        }

        [HttpPut]
        [Route("SetActive")]
        public void SetActive(int categoryId)
        {
            CategoryManager categoryManager = new();
            categoryManager.SetActive(categoryId);
        }
    }
}
