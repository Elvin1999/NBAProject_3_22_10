using NBAProject.ApiEntities;
using NBAProject.Helpers;
using NBAProject.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBAProject.ViewModels
{
    public class MainViewModel:BaseViewModel
    {
		private ObservableCollection<Response> allTeams;

		public ObservableCollection<Response> AllTeams
        {
			get { return allTeams; }
			set { allTeams = value; OnPropertyChanged(); }
		}

        public async void LoadData()
        {
            var service = new NBAService();
            List<Response> result=null;

            if (File.Exists(Constants.TeamsFile))
            {
                result = await JsonHelper<List<Response>>.DeserializeAsync(Constants.TeamsFile);
            }
            else
            {
                result=await service.GetTeamsAsync();
                await JsonHelper<List<Response>>.SerializeAsync(result, Constants.TeamsFile);
            }

            AllTeams = new ObservableCollection<Response>(result);
        }

        public MainViewModel()
        {
            LoadData();
        }
    }
}
