using AirsoftShop.Areas.Admin.Models;
using AirsoftShop.Models;
using Microsoft.AspNetCore.Identity;
using OnlineShop.DB.Models;

namespace AirsoftShop.Helpers
{
    public static class Mapping
    {
        public static List<ProductViewModel> ToProductViewModels(this List<Product> products)
        {
            var productsViewModels = new List<ProductViewModel>();

            foreach (var product in products)
            {
                productsViewModels.Add(ToProductViewModel(product));
            }
            return productsViewModels;
        }

        public static ProductViewModel ToProductViewModel(this Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Cost = product.Cost,
                Descriprion = product.Description,
                ImageUrl = product.ImageUrl
            };
        }

        public static OrderViewModel ToOrderViewModel(this Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                CreateDateTime = order.CreateDateTime,
                Status = (OrderStatusViewModel)(int)order.Status,
                User = ToUserDeliveryInfoViewModel(order.User),
                Items = ToCartItemViewModels(order.Items)
            };
            
        }

        public static UserDeliveryInfoViewModel ToUserDeliveryInfoViewModel(this UserDeliveryInfo deliveryInfo)
        {
            return new UserDeliveryInfoViewModel
            {
                Name = deliveryInfo.Name,
                Address = deliveryInfo.Address,
                Phone = deliveryInfo.Phone
            };
        }
        public static Product ToProduct(this ProductViewModel productViewModel)
        {
            return new Product
            {
                Id = productViewModel.Id,
                Name = productViewModel.Name,
                Cost = productViewModel.Cost,
                Description = productViewModel.Descriprion,
                ImageUrl = productViewModel.ImageUrl
            };
        }

        public static UserDeliveryInfo ToUser(this UserDeliveryInfoViewModel user)
        {
            return new UserDeliveryInfo
            {
                Name = user.Name,
                Address = user.Address,
                Phone = user.Phone,
            };
        }
        public static CartViewModel ToCartViewModel(this Cart cart)
        {
            if (cart == null)
            {
                return null;
            }

            return new CartViewModel
            {
                Id = cart.Id,
                UserId = cart.UserId,
                Items = ToCartItemViewModels(cart.Items)
            };
        }
        public static List<CartItemViewModel> ToCartItemViewModels(this List<CartItem> cartDbItems)
        {
            var cartItems = new List<CartItemViewModel>();

            foreach (var cartDbItem in cartDbItems)
            {
                var cartitem = new CartItemViewModel
                {
                    Id = cartDbItem.Id,
                    Amount = cartDbItem.Amount,
                    Product = ToProductViewModel(cartDbItem.Product)
                };
                cartItems.Add(cartitem);
            }
            return cartItems;
        }

        public static UserDeliveryInfoViewModel UserDeliveryInfoModel(UserDeliveryInfo user)
        {
            return new UserDeliveryInfoViewModel
            {
                Name = user.Name,
                Phone = user.Phone,
                Address = user.Address
            };
        }
        public static UserViewModel ToUserViewModel(this User user)
        {
            return new UserViewModel
            {
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                
            };
        }
        public static RoleViewModel ToRoleViewModel(this IdentityRole role)
        {
            var roleViewModel = new RoleViewModel
            {
                Name = role.Name
            };
            return roleViewModel;
        }

        public static List<RoleViewModel> ToRoleViewModels(this List<IdentityRole> roles)
        {
            var roleViewModels = new List<RoleViewModel>();
            foreach (var role in roles)
            {
                var roleViewModel = role.ToRoleViewModel();
                roleViewModels.Add(roleViewModel);
            }
            return roleViewModels;
        }

        public static User ToUserRegistration(this RegisterViewModel register)
        {
            var user = new User 
            {
                Email = register.Email,
                UserName = register.UserName,
                PasswordHash = register.Password,
                PhoneNumber = register.Phone
            };
            return user;
        }
    }
}

