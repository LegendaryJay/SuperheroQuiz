using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SuperheroQuiz
{
    public partial class MainPage : ContentPage
    {
        SuperheroQuizViewModel viewModel;
        private int _currentQuestionIndex;
        private double _direction;

        public MainPage()
        {
            InitializeComponent();
            viewModel = new SuperheroQuizViewModel();
            CoverImage.Source = ImageSource.FromResource($"SuperheroQuiz.Heroes.unknown.png");
            ResetCards();    
        }

        private void ResetCards()
        {
            CardLayout.Children.Clear();
            viewModel.Reset();
            ToggleVisible(false);
            foreach (var question in viewModel.Questions)
            {
                var questionCard = new QuestionCard
                {
                    CardId = question.Id,
                    Title = question.Title,
                    Yes = question.YesString,
                    No = question.NoString
                };

                var panGesture = new PanGestureRecognizer();
                panGesture.PanUpdated += OnCardPanUpdated;
                questionCard.GestureRecognizers.Add(panGesture);

                CardLayout.Children.Add(questionCard);
                AbsoluteLayout.SetLayoutBounds(questionCard, new Rectangle(0, 0, 1, 1));
                AbsoluteLayout.SetLayoutFlags(questionCard, AbsoluteLayoutFlags.All);
            }


            _currentQuestionIndex = 0;
        }

        private void AnimateCard(View card, double translationX, double rotation, double opacity, uint duration, Action<object, bool> onCompleted = null)
        {
            var translationAnimation = new Animation(v => card.TranslationX = v, card.TranslationX, translationX);
            var rotationAnimation = new Animation(v => card.Rotation = v, card.Rotation, rotation);
            var fadeOutAnimation = new Animation(v => card.Opacity = v, card.Opacity, opacity);
            var animation = new Animation { { 0, 1, translationAnimation }, { 0, 1, rotationAnimation }, { 0, 1, fadeOutAnimation } };
            animation.Commit(this, "SwipeAnimation", 16, duration, Easing.Linear, (v, c) => onCompleted?.Invoke(card, translationX > 0));
        }

        private void OnCardPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            var card = (QuestionCard)sender;

            var maxDist = 100;
            var clampedX = Math.Min(Math.Max(e.TotalX, -maxDist), maxDist);
            var absX = Math.Abs(clampedX);
           
            switch (e.StatusType)
            {
                case GestureStatus.Running:
                    _direction = clampedX / maxDist;
                    card.TranslationX = clampedX;
                    card.Rotation = clampedX / 10;
                    card.Opacity = Math.Max( 1 - absX / maxDist, 0.2);
                    break;
                case GestureStatus.Completed:
                case GestureStatus.Canceled:
                    if (Math.Abs(_direction) > 0.7)
                    {
                        var direction = Math.Round(_direction);
                        AnimateCard(card, direction * Width, direction * 45, 0, 250, (c, isRight) => OnAnswered(viewModel.Questions[card.CardId -1], isRight));
                    }
                    else
                    {
                        AnimateCard(card, 0, 0, 1, 250);
                    }
                    break;
            }
        }


        private void OnAnswered(QuizQuestion question, bool isYes)
        {


            question.Evaluate(isYes);
            _currentQuestionIndex++;
            if (_currentQuestionIndex == viewModel.Questions.Count)
            {
                ShowQuizResult();
            }
        }

        private void ToggleVisible(bool isEnded)
        {
            var value = isEnded ? 1 : 0;
            var notValue = isEnded ? 0 : 1;
            ResultLabel.FadeTo(value, 1500, Easing.Linear);
            ResultImage.FadeTo(value, 1500, Easing.Linear);
            ResetButton.FadeTo(value, 1500, Easing.Linear);
            CoverImage.FadeTo(notValue, 1500, Easing.Linear);
        }

        private void ShowQuizResult()
        {
            var winner = viewModel.SelectWinner();
            ResultLabel.Text = $"You are {winner.Name}!";
            ResultImage.Source = ImageSource.FromResource($"SuperheroQuiz.Heroes.{winner.Image}");
            ToggleVisible(true);
        }

        private void ResetButton_Clicked(object sender, EventArgs e)
        {
            ResetCards();
        }
    }
}
