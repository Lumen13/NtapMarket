using NtapMarket.Data.DBModel;
using NtapMarket.Data.IRepository;
using NtapMarket.Data.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace NtapMarket.Data.Mock.Repository
{
    public class MockProductRepository : IProductModelRepository
    {
        private List<ProductModel> _productModels = new List<ProductModel>()
        {
            new ProductModel()
            {
                Id = 1,
                ProductCategoryId = 1,
                SellerId = 1,
                Count = 1,
                MarketingInfo = "Очень интересная вещь. правда правда",
                Name = "Газонокосилка 3000",
                Price = 30000,

                ProductCategory = new ProductCategory()
                {
                    Id = 1,
                    ParentId = null,
                    Name = "Газонокосилки",
                    Description = "Газонокосилками газонокосилят траву"
                },

                Seller = new Seller()
                {
                    Id = 1,
                    Name = "Борис",
                    Email = "kolbaska@mail.ru",
                    Phone = "88002220022"
                },

                ProductAttributeModel = new List<ProductAttributeModel>()
                {
                    new ProductAttributeModel()
                    {
                        ProductAttributeId = 1,
                        ProductAttributeValueId = 1,
                        Name = "Тип питания",
                        Value = "Бензиновая",
                        Description = "Газонокосилки бензиновые являются самым распространённым типом косилок. " +
                        "Двигатель внутреннего сгорания обеспечивает газонокосилку высокой мощностью, " +
                        "что позволяет использовать их на больших территориях. " +
                        "Основным преимуществом бензиновых газонокосилок является высокая мобильность, " +
                        "другими словами, при работе с такой косилкой нет никаких ограничений в виде кабеля, " +
                        "ограничивающего свободу перемещения косилки. " +
                        "Недостатками бензиновых газонокосилок являются высокий вес, " +
                        "шум при работе и низкая экологичность."
                    },

                    new ProductAttributeModel()
                    {
                        ProductAttributeId = 2,
                        ProductAttributeValueId = 2,
                        Name = "Травосборник",
                        Value = "Жесткий - 40л",
                        Description = ""
                    },

                    new ProductAttributeModel()
                    {
                        ProductAttributeId = 3,
                        ProductAttributeValueId = 4,
                        Name = "Материал корпуса",
                        Value = "Экопластик",
                        Description = ""
                    },

                    new ProductAttributeModel()
                    {
                        ProductAttributeId = 4,
                        ProductAttributeValueId = 3,
                        Name = "Вес",
                        Value = "12 кг",
                        Description = ""
                    }                    
                },

                ProductImage = new List<ProductImage>()
                {
                    new ProductImage()
                    {
                        Id = 1,
                        ProductId = 1,
                        ImageURL = "https://thumb.cloud.mail.ru/weblink/thumb/xw1/cCAz/35U7kkU5m/1.jpg?x-email=ntap.ru%40mail.ru"
                    },

                    new ProductImage()
                    {
                        Id = 2,
                        ProductId = 1,
                        ImageURL = "https://thumb.cloud.mail.ru/weblink/thumb/xw1/2QaK/2y2xF69BZ/11.jpg?x-email=ntap.ru%40mail.ru"
                    },

                    new ProductImage()
                    {
                        Id = 3,
                        ProductId = 1,
                        ImageURL = "https://thumb.cloud.mail.ru/weblink/thumb/xw1/4e6W/2BPnQF4ke/111.jpg?x-email=ntap.ru%40mail.ru"
                    }
                }
            },

            new ProductModel()
            {
                Id = 2,
                SellerId = 2,
                ProductCategoryId = 2,
                Count = 2,
                MarketingInfo = "Тоже интересная вещь. но не очень",
                Name = "Ледяная скорбь",
                Price = 40000,

                ProductCategory = new ProductCategory()
                {
                    Id = 2,
                    ParentId = null,
                    Name = "WoW",
                    Description = "Предметы из вселенной WoW"
                },

                Seller = new Seller()
                {
                    Id = 2,
                    Name = "Ванька",
                    Email = "sosiska@mail.ru",
                    Phone = "88002220021"
                },

                ProductAttributeModel = new List<ProductAttributeModel>()
                {
                    new ProductAttributeModel()
                    {
                        ProductAttributeId = 5,
                        ProductAttributeValueId = 5,
                        Name = "Тип меча",
                        Value = "Длинный меч",
                        Description = "Холодное оружие с прямым клинком, предназначенное для рубящего и колющего ударов, " +
                        "в самом широком смысле — собирательное название всего длинного клинкового оружия с прямым клинком"
                    },

                    new ProductAttributeModel()
                    {
                        ProductAttributeId = 6,
                        ProductAttributeValueId = 6,
                        Name = "Тип эфеса",
                        Value = "Абоюдоровный",
                        Description = ""
                    },

                    new ProductAttributeModel()
                    {
                        ProductAttributeId = 7,
                        ProductAttributeValueId = 7,
                        Name = "Длина лезвия",
                        Value = "80 см",
                        Description = ""
                    }
                },

                ProductImage = new List<ProductImage>()
                {
                    new ProductImage()
                    {
                        Id = 4,
                        ProductId = 2,
                        ImageURL = "https://thumb.cloud.mail.ru/thumb/xw1/Upload/NtapMarket/33.jpg?x-email=ntap.ru%40mail.ru"
                    },

                    new ProductImage()
                    {
                        Id = 5,
                        ProductId = 2,
                        ImageURL = "https://thumb.cloud.mail.ru/thumb/xw1/Upload/NtapMarket/333.jpg?x-email=ntap.ru%40mail.ru"
                    },

                    new ProductImage()
                    {
                        Id = 6,
                        ProductId = 2,
                        ImageURL = "https://thumb.cloud.mail.ru/thumb/xw1/Upload/NtapMarket/3.jpg?x-email=ntap.ru%40mail.ru"
                    }
                }
            },

            new ProductModel()
            {
                Id = 3,
                SellerId = 1,
                ProductCategoryId = 1,
                Count = 1,
                MarketingInfo = "Невероятно бесполезная штука",
                Name = "Урал 880",
                Price = 46500,

                ProductCategory = new ProductCategory()
                {
                    Id = 1,
                    ParentId = null,
                    Name = "Газонокосилки",
                    Description = "Газонокосилками газонокосилят траву"
                },

                Seller = new Seller()
                {
                    Id = 1,
                    Name = "Борис",
                    Email = "kolbaska@mail.ru",
                    Phone = "88002220022"
                },

                ProductAttributeModel = new List<ProductAttributeModel>()
                {
                    new ProductAttributeModel()
                    {
                        ProductAttributeId = 1,
                        ProductAttributeValueId = 8,
                        Name = "Тип питания",
                        Value = "Бензиновая",
                        Description = "Газонокосилки бензиновые являются самым распространённым типом косилок. " +
                        "Двигатель внутреннего сгорания обеспечивает газонокосилку высокой мощностью, " +
                        "что позволяет использовать их на больших территориях. " +
                        "Основным преимуществом бензиновых газонокосилок является высокая мобильность, " +
                        "другими словами, при работе с такой косилкой нет никаких ограничений в виде кабеля, " +
                        "ограничивающего свободу перемещения косилки. " +
                        "Недостатками бензиновых газонокосилок являются высокий вес, " +
                        "шум при работе и низкая экологичность."
                    },

                    new ProductAttributeModel()
                    {
                        ProductAttributeId = 2,
                        ProductAttributeValueId = 9,
                        Name = "Травосборник",
                        Value = "Жесткий - 30л",
                        Description = ""
                    },

                    new ProductAttributeModel()
                    {
                        ProductAttributeId = 3,
                        ProductAttributeValueId = 10,
                        Name = "Материал корпуса",
                        Value = "Металл",
                        Description = ""
                    },

                    new ProductAttributeModel()
                    {
                        ProductAttributeId = 4,
                        ProductAttributeValueId = 11,
                        Name = "Вес",
                        Value = "32 кг",
                        Description = ""
                    }
                },

                ProductImage = new List<ProductImage>()
                {
                    new ProductImage()
                    {
                        Id = 7,
                        ProductId = 3,
                        ImageURL = "https://thumb.cloud.mail.ru/thumb/xw1/Upload/NtapMarket/222.jpeg?x-email=ntap.ru%40mail.ru"
                    },

                    new ProductImage()
                    {
                        Id = 8,
                        ProductId = 3,
                        ImageURL = "https://thumb.cloud.mail.ru/thumb/xw1/Upload/NtapMarket/2.jpeg?x-email=ntap.ru%40mail.ru"
                    },

                    new ProductImage()
                    {
                        Id = 9,
                        ProductId = 3,
                        ImageURL = "https://thumb.cloud.mail.ru/thumb/xw1/Upload/NtapMarket/22.jpeg?x-email=ntap.ru%40mail.ru"
                    }
                }
            },

            new ProductModel()
            {
                Id = 4,
                SellerId = 1,
                ProductCategoryId = 1,
                Count = 3,
                MarketingInfo = "Польза этой вещи весьма сомнительна",
                Name = "Урал Турбо",
                Price = 70500,

                ProductCategory = new ProductCategory()
                {
                    Id = 1,
                    ParentId = null,
                    Name = "Газонокосилки",
                    Description = "Газонокосилками газонокосилят траву"
                },

                Seller = new Seller()
                {
                    Id = 1,
                    Name = "Борис",
                    Email = "kolbaska@mail.ru",
                    Phone = "88002220022"
                },

                ProductAttributeModel = new List<ProductAttributeModel>()
                {
                    new ProductAttributeModel()
                    {
                        ProductAttributeId = 1,
                        ProductAttributeValueId = 12,
                        Name = "Тип питания",
                        Value = "Бензиновая",
                        Description = "Газонокосилки бензиновые являются самым распространённым типом косилок. " +
                        "Двигатель внутреннего сгорания обеспечивает газонокосилку высокой мощностью, " +
                        "что позволяет использовать их на больших территориях. " +
                        "Основным преимуществом бензиновых газонокосилок является высокая мобильность, " +
                        "другими словами, при работе с такой косилкой нет никаких ограничений в виде кабеля, " +
                        "ограничивающего свободу перемещения косилки. " +
                        "Недостатками бензиновых газонокосилок являются высокий вес, " +
                        "шум при работе и низкая экологичность."
                    },

                    new ProductAttributeModel()
                    {
                        ProductAttributeId = 2,
                        ProductAttributeValueId = 13,
                        Name = "Травосборник",
                        Value = "Жесткий - 30л",
                        Description = ""
                    },

                    new ProductAttributeModel()
                    {
                        ProductAttributeId = 3,
                        ProductAttributeValueId = 14,
                        Name = "Материал корпуса",
                        Value = "Металл",
                        Description = ""
                    },

                    new ProductAttributeModel()
                    {
                        ProductAttributeId = 4,
                        ProductAttributeValueId = 15,
                        Name = "Вес",
                        Value = "32 кг",
                        Description = ""
                    }
                },

                ProductImage = new List<ProductImage>()
                {
                    new ProductImage()
                    {
                        Id = 10,
                        ProductId = 4,
                        ImageURL = "https://thumb.cloud.mail.ru/thumb/xw1/Upload/NtapMarket/4.jpg?x-email=ntap.ru%40mail.ru"
                    },

                    new ProductImage()
                    {
                        Id = 11,
                        ProductId = 4,
                        ImageURL = "https://thumb.cloud.mail.ru/thumb/xw1/Upload/NtapMarket/44.jpg?x-email=ntap.ru%40mail.ru"
                    },

                    new ProductImage()
                    {
                        Id = 12,
                        ProductId = 4,
                        ImageURL = "https://thumb.cloud.mail.ru/thumb/xw1/Upload/NtapMarket/444.jpg?x-email=ntap.ru%40mail.ru"
                    }
                }
            }
        };

        public List<ProductModel> GetProductModels(int sellerId)
        {
            var productList = new List<ProductModel>();

            for (int i = 0; i < _productModels.Count; i++)
            {
                if (_productModels[i].SellerId == sellerId)
                {
                    productList.Add(_productModels[i]);
                }
            }

            return productList;
        }

        public ProductModel GetProductModel(int productId)
        {
            var result = _productModels.FirstOrDefault(x => x.Id == productId);

            return result;
        }

        public void PushProductModel(ProductModel productModel)
        {
            
        }

        public ProductModel SetProductModel()
        {
            var productModel = new ProductModel();

            _productModels.Add(productModel);

            return productModel;
        }
    }
}
