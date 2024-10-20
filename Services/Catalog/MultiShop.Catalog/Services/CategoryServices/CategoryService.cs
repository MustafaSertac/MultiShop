using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper,IDatabaseSettings _databaseSetting)
        {
            var client= new MongoClient(_databaseSetting.CategoryCollectionName);
            var database=client.GetDatabase(_databaseSetting.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(_databaseSetting.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
           var value=_mapper.Map<Category>(createCategoryDto); 
            await _categoryCollection.InsertOneAsync(value);

        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _categoryCollection.DeleteOneAsync(category=>category.CategoryId==id) ;
        }

        public async Task<List<ResultCategoryDtos>> GetAllCategoriesAsync()
        {
           var values= await _categoryCollection.Find(category=>true).ToListAsync();

            return _mapper.Map<List<ResultCategoryDtos>>(values);
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
        {
             var values= await _categoryCollection.Find<Category>(category=>category.CategoryId==id).FirstOrDefaultAsync();

            return _mapper.Map<GetByIdCategoryDto>(values);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var values=_mapper.Map<Category>(updateCategoryDto);    
            await _categoryCollection.FindOneAndReplaceAsync(category=>category.CategoryId==updateCategoryDto.CategoryId,values);  

        }
    }
}
