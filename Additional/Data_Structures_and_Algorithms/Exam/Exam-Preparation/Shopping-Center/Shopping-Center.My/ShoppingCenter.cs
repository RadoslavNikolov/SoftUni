using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading;
using Wintellect.PowerCollections;

class ShoppingCenter
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        var center = new ShoppingCenterFast();

        int lineNumber = int.Parse(Console.ReadLine());

        for (int i = 0; i < lineNumber; i++)
        {
            string cmdLine = Console.ReadLine();
            string cmdResult = center.ProcessCommend(cmdLine);
            Console.WriteLine(cmdResult);
        }
    }
}


public class ShoppingCenterFast
{
    private const string PRODUCT_ADDED = "Product added";
    private const string X_PRODUCTS_DELETED = " products deleted";
    private const string NO_PRODUCTS_FOUND = "No products found";
    private const string INCORRECT_COMMAND = "Incorrect command";

    private readonly MultiDictionary<string, Product> productsByName = new MultiDictionary<string, Product>(true);
    private readonly MultiDictionary<string, Product> productsByProducer = new MultiDictionary<string, Product>(true);
    private readonly MultiDictionary<string, Product> productsByNameAndProducer = new MultiDictionary<string, Product>(true);
    private readonly OrderedMultiDictionary<decimal, Product> productByPrice = new OrderedMultiDictionary<decimal, Product>(true); 

    

    public string ProcessCommend(string cmdLine)
    {
        int indexOfFirstSpace = cmdLine.IndexOf(' ');
        string command = cmdLine.Substring(0, indexOfFirstSpace);
        string[] cmdParams = cmdLine.Substring(indexOfFirstSpace + 1)
            .Trim().Split(new char[]{';'}, StringSplitOptions.RemoveEmptyEntries);

        switch (command)
        {
            case "AddProduct":
                return this.AddProduct(cmdParams[0], cmdParams[1], cmdParams[2]);
            case "DeleteProducts" :
                if (cmdParams.Length == 1)
                {
                    return this.DeleteProductsByProducer(cmdParams[0]);
                }
                else
                {
                    return this.DeleteProductsByNameAndProducer(cmdParams[0], cmdParams[1]);
                }
            case "FindProductsByName":
                return this.FindProductsByName(cmdParams[0]);
            case "FindProductsByPriceRange":
                return this.FindProductsByPriceRange(cmdParams[0], cmdParams[1]);
            case "FindProductsByProducer":
                return this.FindProductsByProducer(cmdParams[0]);
            default:
                return INCORRECT_COMMAND;
        }
    }

    private string FindProductsByProducer(string producer)
    {
        var productsFound = this.productsByProducer[producer];

        return this.SortAndPrintProducts(productsFound);
    }

    private string FindProductsByPriceRange(string startPrice, string endPrice)
    {
        decimal fromPrice = decimal.Parse(startPrice);
        decimal toPrice = decimal.Parse(endPrice);

        var productsFound = this.productByPrice.Range(fromPrice, true, toPrice, true).Values;

        return this.SortAndPrintProducts(productsFound);
    }

    private string FindProductsByName(string name)
    {
        var productsFound = this.productsByName[name];

        return this.SortAndPrintProducts(productsFound);

    }

    private string SortAndPrintProducts(IEnumerable<Product> productsToPrint)
    {
        if (!productsToPrint.Any())
        {
            return NO_PRODUCTS_FOUND;
        }

        var sortedProducts = new List<Product>(productsToPrint);
        sortedProducts.Sort();

        var result = new StringBuilder();

        foreach (var product in sortedProducts)
        {
            result.AppendLine(product.ToString());
        }

        return result.ToString().Trim();
    }

    private string DeleteProductsByNameAndProducer(string name, string producer)
    {
       string nameAndProducerKey = this.CombineKeys(name, producer);
       var productsToRemove = this.productsByNameAndProducer[nameAndProducerKey];
       int numDeletedItems = productsToRemove.Count;

        if (!productsToRemove.Any())
        {
            return NO_PRODUCTS_FOUND;
        }

        foreach (var product in productsToRemove)
        {
            this.productsByName.Remove(product.Name, product);        
            this.productsByProducer.Remove(product.Producer, product);
            this.productByPrice.Remove(product.Price, product);
        }

        this.productsByNameAndProducer.Remove(nameAndProducerKey);      
        return numDeletedItems + X_PRODUCTS_DELETED;
    }

    private string DeleteProductsByProducer(string producer)
    {
        var productsToRemove = this.productsByProducer[producer];
        int numDeletedItems = productsToRemove.Count;

        if (!productsToRemove.Any())
        {
            return NO_PRODUCTS_FOUND;
        }


        foreach (var product in productsToRemove)
        {
            this.productsByName.Remove(product.Name, product);         
            this.productsByNameAndProducer.Remove(this.CombineKeys(product.Name, product.Producer), product);
            this.productByPrice.Remove(product.Price, product);
        }

        this.productsByProducer.Remove(producer);      
        return numDeletedItems + X_PRODUCTS_DELETED;
    }

    private string AddProduct(string name, string price, string producer)
    {
        Product product = new Product()
        {
            Name = name,
            Price = decimal.Parse(price),
            Producer = producer
        };

        string nameAndProducerKey = this.CombineKeys(name, producer);

        this.productsByName.Add(name, product);
        this.productsByNameAndProducer.Add(nameAndProducerKey, product);
        this.productsByProducer.Add(producer, product);
        this.productByPrice.Add(product.Price, product);
        
        return PRODUCT_ADDED;
    }

    private string CombineKeys(string name, string producer)
    {
        return name + "|!|" + producer;       
    }
}






//public class ShoppingCenterSlow
//{
//    private const string PRODUCT_ADDED = "Product added";
//    private const string X_PRODUCTS_DELETED = " products deleted";
//    private const string NO_PRODUCTS_FOUND = "No products found";
//    private const string INCORRECT_COMMAND = "Incorrect command";


//    private readonly  List<Product> products = new List<Product>(); 

//    public string ProcessCommend(string cmdLine)
//    {
//        int indexOfFirstSpace = cmdLine.IndexOf(' ');
//        string command = cmdLine.Substring(0, indexOfFirstSpace);
//        string[] cmdParams = cmdLine.Substring(indexOfFirstSpace + 1)
//            .Trim().Split(new char[]{''}, StringSplitOptions.RemoveEmptyEntries);

//        switch (command)
//        {
//            case "AddProduct":
//                return this.AddProduct(cmdParams[0], cmdParams[1], cmdParams[2]);
//            case "DeleteProducts" :
//                if (cmdParams.Length == 1)
//                {
//                    return this.DeleteProductsByProducer(cmdParams[0]);
//                }
//                else
//                {
//                    return this.DeleteProductsByNameAndProducer(cmdParams[0], cmdParams[1]);
//                }
//            case "FindProductsByName":
//                return this.FindProductsByName(cmdParams[0]);
//            case "FindProductsByPriceRange":
//                return this.FindProductsByPriceRange(cmdParams[0], cmdParams[1]);
//            case "FindProductsByProducer":
//                return this.FindProductsByProducer(cmdParams[0]);
//            default:
//                return INCORRECT_COMMAND;
//        }
//    }

//    private string FindProductsByProducer(string producer)
//    {
//        var products = this.products
//            .Where(p => p.Producer == producer)
//            .OrderBy(p => p);

//        return this.PrintProducts(products);
//    }

//    private string FindProductsByPriceRange(string startPrice, string endPrice)
//    {
//        decimal fromPrice = decimal.Parse(startPrice);
//        decimal toPrice = decimal.Parse(endPrice);

//        var products = this.products
//            .Where(p => p.Price >= fromPrice && p.Price <= toPrice)
//            .OrderBy(p => p);

//        return this.PrintProducts(products);
//    }

//    private string FindProductsByName(string name)
//    {
//        var products = this.products
//            .Where(p => p.Name == name)
//            .OrderBy(p => p);

//        return this.PrintProducts(products);

//    }

//    private string PrintProducts(IEnumerable<Product> productsToPrint)
//    {
//        if (!productsToPrint.Any())
//        {
//            return NO_PRODUCTS_FOUND;
//        }

//        var result = new StringBuilder();

//        foreach (var product in productsToPrint)
//        {
//            result.AppendLine(product.ToString());
//        }

//        return result.ToString().Trim();
//    }

//    private string DeleteProductsByNameAndProducer(string name, string producer)
//    {
//        ////one way to solve the problem. Returns numbers of products deleted
//        //int countOffRemovedProducts = this.products.RemoveAll(p => p.Name == name && p.Producer == producer);

//        var productsList = this.products
//            .Where(p => p.Name == name && p.Producer == producer).ToList();

//        if (productsList.Count == 0)
//        {
//            return NO_PRODUCTS_FOUND;
//        }

//        foreach (var product in productsList)
//        {
//            this.products.Remove(product);
//        }

//        return productsList.Count + X_PRODUCTS_DELETED;
//    }

//    private string DeleteProductsByProducer(string producer)
//    {
//        ////one way to solve the problem. Returns numbers of products deleted
//        //int countOffRemovedProducts = this.products.RemoveAll(p => p.Producer == producer);

//        var productsList = this.products.Where(p => p.Producer == producer).ToList();

//        if (productsList.Count == 0)
//        {
//            return NO_PRODUCTS_FOUND;
//        }

//        foreach (var product in productsList)
//        {
//            this.products.Remove(product);
//        }

//        return productsList.Count + X_PRODUCTS_DELETED;
//    }

//    private string AddProduct(string name, string price, string producer)
//    {
//        var product = new Product()
//        {
//            Name = name,
//            Price = decimal.Parse(price),
//            Producer = producer
//        };

//        this.products.Add(product);

//        return PRODUCT_ADDED;
//    }
//}


public class Product : IComparable<Product>
{
    public string Name { get; set; }

    public decimal Price { get; set; }

    public string Producer { get; set; }

    public int CompareTo(Product other)
    {
        int result = this.Name.CompareTo(other.Name);

        if (result == 0)
        {
            result = this.Producer.CompareTo(other.Producer);
        }

        if (result == 0)
        {
            result = this.Price.CompareTo(other.Price);
        }

        return result;
    }

    public override string ToString()
    {
        string result = "{" + this.Name + ";" + this.Producer + ";" + this.Price.ToString("0.00") + "}";

        return result;
    }
}



