using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace ZTSDemo.Web.Pages;

public class IndexModel : ZTSDemoPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
