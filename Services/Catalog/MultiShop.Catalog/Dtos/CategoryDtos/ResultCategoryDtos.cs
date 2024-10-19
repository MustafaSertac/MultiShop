using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MultiShop.Catalog.Dtos.CategoryDtos
{
    public class ResultCategoryDtos
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        
    }

}
