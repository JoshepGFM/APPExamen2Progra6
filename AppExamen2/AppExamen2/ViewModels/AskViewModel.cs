using AppExamen2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace AppExamen2.ViewModels
{
    public class AskViewModel : BaseViewModel
    {
        public Ask MyAsk { get; set; }
        public User MyUser { get; set; }
        public AskStatus MyStatus { get; set; }
        public AskDTO MyAskDTO { get; set; }
        public AskViewModel()
        {
            MyAsk= new Ask();
            MyUser= new User();
            MyStatus= new AskStatus();
            MyAskDTO = new AskDTO();
        }

        public async Task<bool> AddAsk(DateTime pDate,
                                       string pAsk,
                                       int pUserID,
                                       int pAskStatusID,
                                       string pImageURL,
                                       bool pIsStrike,
                                       string pAskDetail)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                MyAsk.Date= pDate;
                MyAsk.AskDescription = pAsk;
                MyAsk.UserId= pUserID;
                MyAsk.AskStatusId = pAskStatusID;
                MyAsk.ImageUrl= pImageURL;
                MyAsk.IsStrike= pIsStrike;
                MyAsk.AskDetail= pAskDetail;

                bool R = await MyAsk.AddAsk();
                return R;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally { IsBusy = false; }
        }

        public async Task<List<AskStatus>> GetStatusList()
        {
            try
            {
                List<AskStatus> list = new List<AskStatus>();
                list = await MyStatus.GetStatus();

                if (list == null)
                {
                    return null;
                }
                else
                {
                    return list;
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<ObservableCollection<AskDTO>> GetFullAskList(bool R)
        {
            if (IsBusy)
            {
                return null;
            }
            else
            {
                IsBusy = true;

                try
                {
                    ObservableCollection<AskDTO> list = new ObservableCollection<AskDTO>();

                    list = await MyAskDTO.GetAskListPed(R);

                    if (list == null)
                    {
                        return null;
                    }

                    return list;
                }
                catch (Exception e)
                {
                    return null;

                }
                finally { IsBusy = false; }

            }

        }
    }
}
