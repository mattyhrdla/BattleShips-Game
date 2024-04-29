using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace projekt_lodě.Models;
{
    public class StartGameModel : PageModel
    {
        public void OnGet()
        {
            // Tato metoda se spustí, když je stránka načtena poprvé
        }

        public IActionResult OnPost(string player, string name)
        {
            // Zpracování dat z formuláře

            // Přesměrování přímo na stránku uvodni.cshtml
            return RedirectToPage("Pages/uvodni");
        }

    }
}
