using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PetShopPatte_Business.DTOs.AnimalTypeDTO;
using PetShopPatte_Business.DTOs.CategoryDTO;
using PetShopPatte_Business.DTOs.ColorDTO;
using PetShopPatte_Business.DTOs.PetDTO;
using PetShopPatte_Business.DTOs.ProductDetailDTO;
using PetShopPatte_Business.DTOs.ProductDTO;
using PetShopPatte_Business.DTOs.SizeDTO;
using PetShopPatte_Business.DTOs.SubcategoryDTO;
using PetShopPatte_Business.Services.Abstracts;
using PetShopPatte_Business.Services.Concretes;
using PetShopPatte_Core.Entities.UserModel;
using PetShopPatte_Data.DAL;
using PetShopPatte_Data.Repositories.Abstracts;
using PetShopPatte_Data.Repositories.Concretes;

namespace PetShop_Patte
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession();

            builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.Password.RequireDigit = true;
                opt.Password.RequireLowercase = true;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = true;
                opt.Password.RequiredLength = 8;
                opt.Password.RequiredUniqueChars = 1;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
                opt.Lockout.MaxFailedAccessAttempts = 5;
                opt.Lockout.AllowedForNewUsers = true;
                opt.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789._";
                opt.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            builder.Services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            });

            builder.Services.AddTransient<IValidator<CategoryCreateDTO>, CategoryCreateDTOValidation>();
            builder.Services.AddTransient<IValidator<CategoryUpdateDTO>, CategoryUpdateDTOValidation>();

            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

            builder.Services.AddTransient<IValidator<ColorCreateDTO>, ColorCreateDTOValidation>();
            builder.Services.AddTransient<IValidator<ColorUpdateDTO>, ColorUpdateDTOValidation>();

            builder.Services.AddScoped<IColorService, ColorService>();
            builder.Services.AddScoped<IColorRepository, ColorRepository>();

            builder.Services.AddScoped<IBasketRepository, BasketRepository>();
            builder.Services.AddScoped<IBasketService, BasketService>();

            builder.Services.AddTransient<IValidator<PetCreateDTO>, PetCreateDTOValidation>();
            builder.Services.AddTransient<IValidator<PetUpdateDTO>, PetUpdateDTOValidation>();

            builder.Services.AddScoped<IPetService, PetService>();
            builder.Services.AddScoped<IPetRepository, PetRepository>();

            //builder.Services.AddTransient<IValidator<ProductCreateDTO>, ProductCreateDTOValidation>();
            builder.Services.AddTransient<IValidator<ProductUpdateDTO>, ProductUpdateDTOValidation>();

            //builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();

            //builder.Services.AddTransient<IValidator<ProductDetailCreateDTO>, ProductDetailCreateDTOValidation>();
            builder.Services.AddTransient<IValidator<ProductDetailUpdateDTO>, ProductDetailUpdateDTOValidation>();

            //builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
            builder.Services.AddScoped<IProductDetailRepository, ProductDetailRepository>();

            builder.Services.AddTransient<IValidator<AnimalTypeCreateDTO>, AnimalTypeCreateDTOValidation>();
            builder.Services.AddTransient<IValidator<AnimalTypeUpdateDTO>, AnimalTypeUpdateDTOValidation>();

            builder.Services.AddScoped<IAnimalTypeService, AnimalTypeService>();
            builder.Services.AddScoped<IAnimalTypeRepository, AnimalTypeRepository>();

            builder.Services.AddTransient<IValidator<SubcategoryCreateDTO>, SubcategoryCreateDTOValidation>();
            builder.Services.AddTransient<IValidator<SubcategoryUpdateDTO>, SubcategoryUpdateDTOValidation>();

            builder.Services.AddScoped<ISubcategoryService, SubcategoryService>();
            builder.Services.AddScoped<ISubcategoryRepository, SubcategoryRepository>();

            builder.Services.AddTransient<IValidator<SizeCreateDTO>, SizeCreateDTOValidation>();
            builder.Services.AddTransient<IValidator<SizeUpdateDTO>, SizeUpdateDTOValidation>();

            builder.Services.AddScoped<ISizeService, SizeService>();
            builder.Services.AddScoped<ISizeRepository, SizeRepository>();

            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<ISendMessageService, SendMessageService>();

            builder.Services.AddAutoMapper(typeof(Program).Assembly);


            var app = builder.Build();

            app.UseSession();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
            );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
