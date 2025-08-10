using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestExtractor
{
    /// <summary>
    /// Représente la structure de la réponse JSON de l'API de vérification de compte.
    /// </summary>
    public class ApiAccountResponse
    {
        public string credit { get; set; }
        public string region { get; set; }
        public string status { get; set; }
        public string token { get; set; }
        public string token_access { get; set; }
        public string uid { get; set; }
    }

    /// <summary>
    /// Représente un objet de compte invité extrait du fichier guest_accounts.json.
    /// </summary>
    public class GuestAccountInfo
    {
        public string uid { get; set; }
        public string password { get; set; }
    }
}