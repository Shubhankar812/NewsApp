using NewsApp.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.MVVM.ViewModel
{
    public class NewsViewModel
    {
        public Root News { get; set; }

        public ObservableCollection<Article> Articles { get; set; }

        public List<Article> ArticlesList { get; set; }
        public NewsViewModel()
        {
            Articles = new ObservableCollection<Article>();
            ArticlesList = new List<Article>();
           
          //  LoadArticle();
        }


        public async Task<List<Article>> LoadNews(string newsTopic)
        {
           
            var rootNews = await APIData.GetNews(newsTopic);


            foreach (var item in rootNews.Articles)
            {
                ArticlesList.Add(item);
            }

          
            return ArticlesList;
        }

    }
}
