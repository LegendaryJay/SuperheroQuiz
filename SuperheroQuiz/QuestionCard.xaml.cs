using System;
using Xamarin.Forms;

namespace SuperheroQuiz
{
    public partial class QuestionCard : Frame
    {
        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create(nameof(Title), typeof(string), typeof(QuestionCard));

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public static readonly BindableProperty YesProperty =
            BindableProperty.Create(nameof(Yes), typeof(string), typeof(QuestionCard));

        public string Yes
        {
            get => (string)GetValue(YesProperty);
            set => SetValue(YesProperty, value);
        }

        public static readonly BindableProperty NoProperty =
            BindableProperty.Create(nameof(No), typeof(string), typeof(QuestionCard));

        public string No
        {
            get => (string)GetValue(NoProperty);
            set => SetValue(NoProperty, value);
        }

        public static readonly BindableProperty IdProperty =
            BindableProperty.Create(nameof(CardId), typeof(int), typeof(QuestionCard));

        public int CardId
        {
            get => (int)GetValue(IdProperty);
            set => SetValue(IdProperty, value);
        }

        public QuestionCard()
        {
            InitializeComponent();

            BindingContext = this;
        }
    }
}
