using System.Collections.Generic;
using System.Threading.Tasks;
using MesGaranties.WinPhone.Core.ApiConnector.Models.Garantie;
using MesGaranties.WinPhone.Core.ApiRequest;
using Newtonsoft.Json;

namespace MesGaranties.WinPhone.Core.ApiConnector.Connectors
{
    public class GarantieConnector
    {
        /// <summary>
        /// Get the current user garanties
        /// </summary>
        /// <returns></returns>
        public async Task<List<GarantieModel>> GetGaranties()
        {
            var result = await RequestGenerator.GetRequest("Me/Garanties");
            result.EnsureSuccessStatusCode();//throw excep
            var str = await result.Content.ReadAsStringAsync();
            var deserialized = JsonConvert.DeserializeObject<List<GarantieModel>>(str);
            return deserialized;
        }

        /// <summary>
        /// post a new garantie
        /// </summary>
        /// <param name="garantie"></param>
        /// <returns></returns>
        public async Task<GarantieDetailModel> PostGarantie(GarantieDetailModel garantie)
        {
            return
                await PostGarantie(new GarantieCreateModel()
                {
                    Commentaire = garantie.Commentaire,
                    EndDate = garantie.EndDate,
                    Name = garantie.Name
                });
        }

        /// <summary>
        /// post a new garantie
        /// </summary>
        /// <param name="garantie"></param>
        /// <returns></returns>
        public async Task<GarantieDetailModel> PostGarantie(GarantieCreateModel garantie)
        {
            var body = JsonConvert.SerializeObject(garantie);
            var result = await RequestGenerator.PostRequest("Me/Garanties",body);
            result.EnsureSuccessStatusCode();//throw excep
            var str = await result.Content.ReadAsStringAsync();
            var deserialized = JsonConvert.DeserializeObject<GarantieDetailModel>(str);
            return deserialized;
        }

        /// <summary>
        /// edit a garantie
        /// </summary>
        /// <param name="garantie"></param>
        /// <returns></returns>
        public async Task<GarantieDetailModel> PutGarantie(GarantieDetailModel garantie)
        {
            return
                await PutGarantie(
                    new GarantieModifModel()
                    {
                        Commentaire = garantie.Commentaire,
                        EndDate = garantie.EndDate,
                        Name = garantie.Name
                    }, garantie.Id);
        }

        /// <summary>
        /// edit a garantie
        /// </summary>
        /// <param name="garantie"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GarantieDetailModel> PutGarantie(GarantieModifModel garantie,int id)
        {
            var body = JsonConvert.SerializeObject(garantie);
            var result = await RequestGenerator.PutRequest(string.Format("Garanties/{0}", id), body);
            result.EnsureSuccessStatusCode();//throw excep
            var str = await result.Content.ReadAsStringAsync();
            var deserialized = JsonConvert.DeserializeObject<GarantieDetailModel>(str);
            return deserialized;
        }
    }
}
