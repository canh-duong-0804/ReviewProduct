using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration.UserSecrets;
using ProductReview.Models;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Security.Cryptography.Xml;

namespace ProductReview.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            using (PRN211Context context = new PRN211Context())
            {
                Console.WriteLine("hello");

                var products = context.Products.Where(p => p.Category == "Tech").ToList();
                ViewBag.Beuty = context.Products.Where(p => p.Category == "Beuty").ToList();
                return View(products);
            }

        }

        public IActionResult AddProduct()
        {

            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product P, IFormFile? Img)
        {
            //Console.WriteLine($"Product {P.Category}");
            Console.WriteLine("fun addProduct");
            Console.WriteLine(P.Image);
            Console.WriteLine("file name:" + Img.FileName);
            foreach (var check in ModelState.Values)
            {
                Console.WriteLine(check.RawValue + " " + check.ValidationState);

            }
            using (PRN211Context context = new PRN211Context())
            {
                //String name = HttpContext.Session.GetString("User");
                Console.WriteLine("check: " + ModelState.IsValid);
                if (ModelState.IsValid)
                {
                    var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", Img.FileName);
                    using (var filestream = new FileStream(filepath, FileMode.Create))
                    {
                        Img.CopyTo(filestream);
                    };

                    context.Products.Add(P);
                    context.SaveChanges();
                    //var products = context.Products.ToList();
                    return RedirectToAction("ProductMenu");
                }
                else
                {
                    Console.WriteLine("add fail");
                    return View();
                }
            }



        }
        public IActionResult ProductMenu(String key=null)
        {
            using (PRN211Context context = new PRN211Context())
            {
                if (!String.IsNullOrEmpty(key))
                {
                    ViewBag.products = context.Products
                        .Where(e => (e.ProductName.Contains(key)))
                            .ToList();
                    ViewBag.key = key;
                    return View();
                }
                else
                {

                    ViewBag.products = context.Products.ToList();
                    return View();
                }

            }
        }
        [HttpGet]
        public IActionResult ProductDetail(int id)
        {
            using (PRN211Context ctx = new PRN211Context())
            {

                var product = ctx.Products.FirstOrDefault(p => p.ProductId == id);
                int count = ctx.Reviews.Count(p => p.ProductId == id);
                ViewBag.Count = count;
                ViewBag.Review = ctx.Reviews.Where(p => p.ProductId == id).ToList();
                var review = ctx.Reviews.Where(p => p.ProductId == id).ToList();
                int sumRatings = (int)review.Sum(review => review.Rating);
                if (count > 0)
                {
                    sumRatings = sumRatings / count;
                }
                else { sumRatings = 0; }

                ViewBag.SumRatings = sumRatings;
                return View(product);
            }


        }
        [HttpPost]
        public IActionResult Review(int ProductID, int rating, String comment)
        {
            List<Review> reviews = new List<Review>();
            Review review;
            using (PRN211Context context = new PRN211Context())
            {

                int? UserID = HttpContext.Session.GetInt32("UserID");
                if (UserID.HasValue)
                {
                    review = context.Reviews.FirstOrDefault(p => p.ProductId == ProductID && p.UserId == UserID);
                    if (review == null)
                    {
                        // Check if UserID has a value (is not null)

                        Review rv = new Review(ProductID, UserID.Value, rating, comment, DateTime.Now);

                        context.Reviews.Add(rv);
                        context.SaveChanges();
                        return RedirectToAction("ProductDetail", new { id = ProductID });
                    }

                    // Handle the case where UserID is null, if needed
                    else
                    {
                        DateTime now = DateTime.Now;
                        String final = review.ReviewText + " \n Posted at:" + now + " \n " + comment;


                        review.ReviewText = final;
                        context.Update(review);
                        context.SaveChanges();
                        return RedirectToAction("ProductDetail", new { id = ProductID });
                    }

                }
                else
                {
                    TempData["alert"] = "Please login before commenting";
                    return Redirect("~/Login/Index");
                }



            }


        }
        public IActionResult UpdateProduct(int id)
        {

            using (PRN211Context context = new())
            {
                ViewBag.pro = context.Products.ToList();
                Product product = context.Products.FirstOrDefault(b => b.ProductId == id);
                return View(product);
            }


        }
        [HttpPost]
        public IActionResult UpdateProduct(Product? pro, IFormFile? Img)
        {

            Console.WriteLine("da dc goi den");
            Console.WriteLine("id: " + pro.ProductId);
            foreach (var check in ModelState.Values)
            {
                Console.WriteLine(check.RawValue + " " + check.ValidationState);

            }

            using (PRN211Context context = new())
            {
                Console.WriteLine("check: " + ModelState.IsValid);
                if (ModelState.IsValid)
                {
                    Product product = context.Products.FirstOrDefault(b => b.ProductId == pro.ProductId);
                    Console.WriteLine("check: " + product.Image);
                    if (!pro.Image.Equals(product.Image))
                    {
                        var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", Img.FileName);
                        using (var filestream = new FileStream(filepath, FileMode.Create))
                        {
                            Img.CopyTo(filestream);
                        };
                    }
                    product.Image = pro.Image;
                    product.Category = pro.Category;
                    product.ProductName = pro.ProductName;
                    product.Description = pro.Description;
                    product.Brand = pro.Brand;
                    product.ReleaseDate = pro.ReleaseDate;
                    product.Price = pro.Price;

                    context.SaveChanges();
                    Console.WriteLine("update fail");
                    ViewBag.success = "ok";
                }
                ViewBag.cates = context.Products.ToList();
            }
            return RedirectToAction("ProductMenu");


        }
        public IActionResult DeleteBlog(int id)
        {

            using (PRN211Context context = new())
            {
                var all = context.Reviews.Where(c => c.ReviewId == id).ToList();
                if (all != null && all.Count > 0)
                {
                    context.Reviews.RemoveRange(all);
                    context.SaveChanges();
                }
                Product pro = context.Products.FirstOrDefault(b => b.ProductId == id);
                context.Products.Remove(pro); context.SaveChanges();
            }
            return RedirectToAction("ProductMenu");



        }


    }
}
