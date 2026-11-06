using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp.Namespace
{
    public class vector_hoyModel : PageModel
    {
        public string[,] personas { get; set; } = new string[2, 3];

        public void OnGet()
        {
            personas[0, 0] = "Ana";
            personas[0, 1] = "Luis";
            personas[0, 2] = "Marta";
            personas[1, 0] = "Juan";
            personas[1, 1] = "Sofía";
            personas[1, 2] = "Lina";
        }
    }
}
