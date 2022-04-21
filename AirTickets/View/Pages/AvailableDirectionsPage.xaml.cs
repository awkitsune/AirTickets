using AirTickets.Core.GridViewTemplates;
using ModernWpf.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AirTickets.View.Pages
{
	/// <summary>
	/// Логика взаимодействия для AvailableDirectionsPage.xaml
	/// </summary>
	public partial class AvailableDirectionsPage : System.Windows.Controls.Page
	{
        public AvailableDirectionsPage()
		{
			InitializeComponent();

			countryComboBox.SelectedIndex = 0;
		}

		private void ComboBox_Selected(object sender, RoutedEventArgs e)
		{
			var destinations = new ObservableCollection<DestinationItem>();

			if (((ComboBox)sender).SelectedIndex == 0)
			{
				destinations.Add(new DestinationItem()
				{
					Name = "Кисловодские минеральные воды",
					Address = "Минеральные Воды, Россия",
					Description = "Как добраться: поездом прямо до Кисловодска или самолетом до Минеральных Вод, а дальше полтора часа на автобусе, маршрутке или электричке. Если водите, еще удобнее взять машину напрокат в аэропорту Минвод.\n\n" +
						"Чтобы провести лето на курорте в прямом смысле этого слова, поезжайте на воды — Кавказские Минеральные.\n" +
						"В Кисловодске ностальгия без советского привкуса разлита прямо в воздухе.В местных спа-отелях и санаториях хорошо всей семьей. Пока взрослые принимают нарзанные ванны, расслабляются под руками массажиста и пыхтят в парной, малыши исследуют соляные пещеры, резвятся в бассейнах и играют в детских клубах."
				});
				destinations.Add(new DestinationItem()
				{
					Name = "Куршская коса",
					Address = "Калининград, Россия",
					Description = "Как добраться: самолетом до Калининграда, оттуда на электричке до Зеленоградска.\n\n" +
						"Россию и Литву соединяет длиннющая песчаная коса: приезжаешь — и попадаешь в сказку. Ну а как еще назвать место, где танцуют сосны, поют корольки и пеночки, дюны тянутся до самого горизонта, а с обеих сторон плещутся лазурные волны? Среди природных чудес проложены пешеходные маршруты, а в музее под открытым небом «Древняя Самбия» викинги научат вас стрелять из самострела." +
						"Куршский залив прогревается уже в июне, Балтийское море теплеет к середине лета — купайтесь с какой хотите стороны. С жильем тоже проблем не будет: поселитесь в частном доме на самой косе или в любом отеле Зеленоградска «на материке»."
				});
				destinations.Add(new DestinationItem()
				{
					Name = "Белокуриха",
					Address = "Новосибирск, Россия",
					Description = "Как добраться: на самолете до Новосибирска, оттуда на прямом автобусе до Белокурихи.\n\n" +
						"Когда хочется, чтобы все вокруг выключили звук и оставили вас в покое, надо ехать на Алтай.\n" +
						"Тишина, горный воздух и пантовые ванны — все это включено в отдых на курорте Белокуриха в двух часах езды от Горно-Алтайска. Еще этот городок, уютно запрятанный между лесами и горами, прославился термальными источниками и тропками-терренкурами. \n" +
						"После пары дней горных прогулок вы из Атланта со вселенским грузом на плечах превратитесь в Гермеса на крылатых сандалиях."
				});
				destinations.Add(new DestinationItem()
				{
					Name = "Заповедник «Хакасский»",
					Address = "Абакан, Россия",
					Description = "Как добраться: самолетом до Абакана, дальше до озер на поезде, машине или автобусе.\n\n" +
						"В Хакасию приезжайте, чтобы пожить на озерах. Самое большое — минеральное Белё. Поселитесь в юрте на берегу, попарьтесь в бане, а с утра освежитесь в прозрачной воде и помашите пролетающим орлам.\n" +
						"Если хотите подлечиться, остановитесь в санатории на озере Шира. Там знают, куда намазать иловую грязь и сколько прописать минералки, чтобы пациенты стали бодрее коньков-горбунков.\n" +
						"Рыбачить отправляйтесь на пресное озеро Иткуль. Уха из окуня и леща будет еще вкуснее, если сварите ее на костре у палатки."
				});
			}

			destinationsGridView.ItemsSource = destinations;
		}

		private void destinationsGridView_ItemClick1(object sender, ModernWpf.Controls.ItemClickEventArgs e)
		{

		}

		private void destinationsGridView_ItemClick(object sender, ItemClickEventArgs e)
		{
			var card = (DestinationItem)e.ClickedItem;
			var destWnd = new DestinationSelectionWindow(card);
			destWnd.Owner = Window.GetWindow(this);
			destWnd.ShowDialog();
		}
	}
}
