using AutoMapper;
using InventoryBL.DTOs.Commands;
using InventoryBL.Models;

namespace InventoryBL.DTOs
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            //PRODUCT
            CreateMap<Product, ProductDTO>(); //GET
            CreateMap<ProductDTO, Product>(); //POST - PUT

            CreateMap<Product, ProductCommandDTO>(); //GET
            CreateMap<ProductCommandDTO, Product>(); //POST - PUT

            //ITEM
            CreateMap<Item, ItemDTO>();
            CreateMap<ItemDTO, Item>();

            CreateMap<Item, ItemCommandDTO>();
            CreateMap<ItemCommandDTO, Item>();

            //ORDER
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderDTO, Order>();

            CreateMap<Order, OrderCommandDTO>();
            CreateMap<OrderCommandDTO, Order>();

            //ORDER-DETAIL
            CreateMap<OrderDetail, OrderDetailCommandDTO>();
            CreateMap<OrderDetailCommandDTO, OrderDetail>();

            CreateMap<OrderDetail, OrderDetailCommandDTO>();
            CreateMap<OrderDetailCommandDTO, OrderDetail>();
        }
    }
}
