using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop
{
    public partial class eShopConsole
    {
        private bool CartMenu()
        {
            Console.Clear();
            Console.WriteLine("1) Add to Cart");
            Console.WriteLine("2) Remove from Cart");
            Console.WriteLine("3) View Cart");
            Console.WriteLine("4) Checkout");
            Console.WriteLine("0) Main Menu");

            Console.Write("\nSelect an option:");
            switch (Console.ReadLine())
            {
                case "0":
                    return false;
                case "1":
                    AddProductToCart();
                    break;
                case "2":
                    RemoveProductFromCart();
                    break;
                case "3":
                    ViewCart();
                    break;
                case "4":
                    Checkout();
                    break;
                default:
                    break;
            }

            return true;
        }

        private void AddProductToCart()
        {
            var productList = _productService.GetProducts();

            while (true)
            {
                bool incrementQtyFlag = false;

                Console.Clear();

                productList.ForEach(product => Console.WriteLine($" {product.Id} - {product.Name}\n {product.Price:c}\n {product.Stock} in stock\n"));
                int inputProductId = GetIntInput("\nAdd Product: ");

                var productAux = productList.Find(product => product.Id == inputProductId);

                if (productAux == null)
                {
                    Console.WriteLine($"Product {inputProductId} doesn't exist!");
                    Console.WriteLine("\n Press any key to continue...");
                    Console.ReadLine();
                    continue;
                }

                Product product = null;

                if (_cartService.ProductInCart(inputProductId))
                {
                    product = _cartService.GetProductFromCart(inputProductId);
                    incrementQtyFlag = true;
                }
                else 
                {
                    product = new Product(productAux.Id, productAux.Name, productAux.Description, productAux.Price, productAux.Brand, productAux.Sku);
                }

                int cartProductQty = 0;
                bool maxedOut = false;

                while (true)
                {
                    int maxQtyAvailable = incrementQtyFlag ? productAux.Stock - product.Stock : productAux.Stock;
                    
                    if (maxQtyAvailable <= 0)
                    {
                        if (incrementQtyFlag)
                            Console.WriteLine($"You already have all the available {product.Name} in your cart!");
                        else
                            Console.WriteLine($"There are no {product.Name} in stock!");

                        Console.WriteLine("\n Press any key to continue...");
                        Console.ReadLine();
                        maxedOut = true;

                        break;
                    }

                    cartProductQty = GetIntInput(incrementQtyFlag ? "Product already in cart. Increment Qty by: " : "Hoy many do you want to add?: ");

                    if (cartProductQty <= 0 || cartProductQty > maxQtyAvailable) 
                    {
                        Console.WriteLine($"Quantity must be between 1 and {maxQtyAvailable}");
                        Console.WriteLine("\n Press any key to continue...");
                        Console.ReadLine();
                        continue;
                    }

                    break;
                }

                if (!maxedOut) 
                {
                    if (incrementQtyFlag)
                        product.AddStock(cartProductQty);
                    else
                        product.UpdateStock(cartProductQty);

                    if (!incrementQtyFlag)
                    {
                        _cartService.AddProduct(product);
                        Console.WriteLine($"Product {product.Id} was added to your cart");
                    }
                    else
                    {
                        Console.WriteLine($"Product {product.Id} quantity successfully updated");
                    }
                }

                string continueShopping;
                while (true)
                {
                    continueShopping = GetStringInput("Do you want to continue shopping? (y/n): ");
                    if (continueShopping.ToLower() == "y" || continueShopping.ToLower() == "n")
                        break;
                }

                if (continueShopping == "y")
                {
                    continue;
                }
                else
                {
                    _cartService.CalculateTotal();
                    break;
                }
            }

            Console.Write("\nPress any key to continue...");
            Console.ReadLine();
        }

        private void RemoveProductFromCart() 
        {
            Console.Clear();

            var cart = _cartService.GetCart();

            if (cart.Products.Any())
            {
                Console.WriteLine(cart);

                int productToRemove = 0;
                Product product = null;

                while (true)
                {
                    productToRemove = GetIntInput("Product to remove: ");

                    product = cart.Products.Find(product => product.Id == productToRemove);

                    if (product is null)
                    {
                        Console.WriteLine($"Product {productToRemove} is not in your cart!");
                        Console.Write("\nPress any key to continue...");
                        Console.ReadLine();
                        continue;
                    }

                    break;
                }

                int qtyToRemove = 0;

                while (true)
                {
                    qtyToRemove = GetIntInput("Quantity to remove: ");

                    if (qtyToRemove <= 0 || qtyToRemove > product.Stock)
                    {
                        Console.WriteLine($"Qty must be between 1 and {product.Stock}");
                        Console.Write("\nPress any key to continue...");
                        Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }

                if (qtyToRemove == product.Stock)
                {
                    _cartService.RemoveProduct(product.Id);
                }
                else
                {
                    _cartService.UpdateProductQuantity(product.Id, (product.Stock - qtyToRemove));
                }

                Console.WriteLine("\nProduct removed");
                _cartService.CalculateTotal();
            }
            else 
            {
                Console.WriteLine("Your Cart is Empty");
            }

            Console.Write("\nPress any key to continue...");
            Console.ReadLine();
        }

        private void ViewCart()
        {
            Console.Clear();

            var cart = _cartService.GetCart();

            if (cart.Products.Any())
                Console.WriteLine(cart);
            else
                Console.WriteLine("Your cart is empty");

            Console.Write("\nPress any key to continue...");
            Console.ReadLine();
        }

        private void Checkout() 
        {
            Console.Clear();

            var cart = _cartService.GetCart();

            if (cart.Products.Any())
            {
                Console.WriteLine(cart);

                string performCheckout;
                while (true)
                {
                    performCheckout = GetStringInput("Do you want to checkout? (y/n): ");
                    if (performCheckout.ToLower() == "y" || performCheckout.ToLower() == "n")
                        break;
                }

                if (performCheckout == "y") 
                {
                    List<Product> orderProducts = new();

                    foreach (var p in cart.Products) 
                        orderProducts.Add(new Product(p.Id, p.Name, p.Description, p.Price, p.Brand, p.Sku, p.Stock));

                    Order order = new(orderProducts);

                    orderProducts
                        .GroupBy(product => product.Id)
                        .Select(group => new { Id = group.Key, Qty = group.Sum(product => product.Stock) })
                        .ToList()
                        .ForEach(product => _productService.GetProduct(product.Id).AddStock(-product.Qty));

                    _orderService.CreateOrder(order);
                    _cartService.ClearCart();

                    Console.WriteLine($"Your Order Number is: #{order.Id}");
                }
            }
            else 
            {
                Console.WriteLine("Your cart is empty");
            }

            Console.Write("\nPress any key to continue...");
            Console.ReadLine();

        }
    }
}
