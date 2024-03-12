using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftUniBazar.Data;
using SoftUniBazar.Data.Models;
using SoftUniBazar.Models;
using System.Globalization;
using System.Security.Claims;
using System.Xml.Linq;

namespace SoftUniBazar.Controllers
{
    [Authorize]
    public class AdController : Controller
    {
        private readonly BazarDbContext data;

        public AdController(BazarDbContext context)
        {
            data = context;
        }

        public async Task<IActionResult> All()
        {
            var ads = await data.Ads
                .AsNoTracking()
                .Select(a => new AllAdsViewModel(
                    a.Id,
                    a.Name,
                    a.ImageUrl,
                    a.Category.Name,
                    a.CreatedOn,
                    a.Description,
                    a.Price,
                    a.Owner.UserName
                    ))
                .ToListAsync();

            return View(ads);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int id)
        {
            var ad = await data.Ads
                .FindAsync(id);

            if (ad == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            var entry = new AdBuyer()
            {
                AdId = ad.Id,
                BuyerId = userId
            };

            if (await data.AdsBuyers.ContainsAsync(entry))
            {
                return RedirectToAction("All", "Ad");
            }

            await data.AddAsync(entry);
            await data.SaveChangesAsync();

            return RedirectToAction("Cart", "Ad");
        }

        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            string userId = GetUserId();

            var model = await data.AdsBuyers
                .Where(ap => ap.BuyerId == userId)
                .AsNoTracking()
                .Select(ap => new AllAdsViewModel(
                    ap.AdId,
                    ap.Ad.Name,
                    ap.Ad.ImageUrl,
                    ap.Ad.Category.Name,
                    ap.Ad.CreatedOn,
                    ap.Ad.Description,
                    ap.Ad.Price,
                    ap.Ad.Owner.UserName
                    ))
                .ToListAsync();

            return View(model);
        }

        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var ad = await data.Ads
               .FindAsync(id);

            if (ad == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            var entry = await data.AdsBuyers.FirstOrDefaultAsync(ab => ab.BuyerId == userId && ab.AdId == id);

            if (entry == null)
            {
                return BadRequest();
            }

            data.AdsBuyers.Remove(entry);

            await data.SaveChangesAsync();

            return RedirectToAction("All", "Ad");
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AdFormViewModel();
            model.Categories = await GetTypes();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AdFormViewModel model)
        {

            if (!ModelState.IsValid)
            {
                model.Categories = await GetTypes();

                return View(model);
            }

            var ad = new Ad()
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                OwnerId = GetUserId(),
                ImageUrl = model.ImageUrl,
                CreatedOn = DateTime.Now,
                CategoryId = model.CategoryId
            };

            await data.Ads.AddAsync(ad);

            await data.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var adToEdit = await data.Ads.FindAsync(id);

            if (adToEdit == null)
            {
                return BadRequest();
            }

            if (adToEdit.OwnerId != GetUserId())
            {
                return Unauthorized();
            }

            var model = new AdFormViewModel
            {
                Name = adToEdit.Name,
                Description = adToEdit.Description,
                Price = adToEdit.Price,
                ImageUrl = adToEdit.ImageUrl,
                CategoryId = adToEdit.CategoryId,
                Categories = await GetTypes()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AdFormViewModel model, int id)
        {
            var ad = await data.Ads.FindAsync(id);

            if (ad == null)
            {
                return BadRequest();
            }

            if (ad.OwnerId != GetUserId())
            {
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await GetTypes();

                return View(model);
            }

            ad.Description = model.Description;
            ad.Price = model.Price;
            ad.Name = model.Name;
            ad.ImageUrl = model.ImageUrl;
            ad.CategoryId = model.CategoryId;

            await data.SaveChangesAsync();
            return RedirectToAction(nameof(All));
        }

        private async Task<IEnumerable<CategoryViewModel>> GetTypes()
        {
            return await data.Categories
                .AsNoTracking()
                .Select(c => new CategoryViewModel
                {
                    Name = c.Name,
                    Id = c.Id
                })
                .ToListAsync();
        }

        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }
    }
}