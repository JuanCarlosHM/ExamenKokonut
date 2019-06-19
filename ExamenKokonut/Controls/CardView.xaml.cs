namespace ExamenKokonut.Controls
{
    using System;
    using Xamarin.Forms;

    public partial class CardView : Frame
    {

        #region BlindableProperties 
        public static readonly BindableProperty BoxCardColorProperty = BindableProperty.Create(
               nameof(BoxCardColor),
               typeof(string),
               typeof(CardView),
               default(string),
               BindingMode.OneWay);

        public static readonly BindableProperty ImgCardProperty = BindableProperty.Create(
               nameof(ImgCard),
               typeof(Uri),
               typeof(CardView),
               default(Uri),
               BindingMode.OneWay);

        public static readonly BindableProperty ImgCardPropertyLocalSource = BindableProperty.Create(
              nameof(ImgCard),
              typeof(ImageSource),
              typeof(CardView),
              default(string),
              BindingMode.OneWay);

        public static readonly BindableProperty TitleProperty = BindableProperty.Create(
               nameof(Title),
               typeof(string),
               typeof(CardView),
               default(string),
               BindingMode.OneWay);

        public static readonly BindableProperty ShortDescriptProperty = BindableProperty.Create(
                nameof(ShortDescript),
                typeof(string),
                typeof(CardView),
                default(string),
                BindingMode.OneWay);

        public static readonly BindableProperty ButtonTitleProperty = BindableProperty.Create(
                nameof(ButtonTitle),
                typeof(string),
                typeof(CardView),
                default(string),
                BindingMode.OneWay);

        public static readonly BindableProperty ButtonActionOneProperty = BindableProperty.Create(
                nameof(buttonActionOne),
                typeof(string),
                typeof(CardView),
                default(string),
                BindingMode.OneWay);

        public static readonly BindableProperty ButtonActionTwoProperty = BindableProperty.Create(
                nameof(Title),
                typeof(string),
                typeof(CardView),
                default(string),
                BindingMode.OneWay);
        #endregion


        #region Properties
        public string BoxCardColor
        {
            get
            {
                return (string)GetValue(BoxCardColorProperty);
            }

            set
            {
                SetValue(BoxCardColorProperty, value);
            }
        }

        public Uri ImgCard
        {
            get
            {
                return (Uri)GetValue(ImgCardProperty);
            }

            set
            {
                SetValue(ImgCardProperty, value);
            }
        }

        public ImageSource ImgCardLocalSource
        {
            get
            {
                return (ImageSource)GetValue(ImgCardPropertyLocalSource);
            }

            set
            {
                SetValue(ImgCardPropertyLocalSource, value);
            }
        }


        public string Title
        {
            get
            {
                return (string)GetValue(TitleProperty);
            }

            set
            {
                SetValue(TitleProperty, value);
            }
        }

        public string ShortDescript
        {
            get
            {
                return (string)GetValue(ShortDescriptProperty);
            }

            set
            {
                SetValue(ShortDescriptProperty, value);
            }
        }

        public string ButtonTitle
        {
            get
            {
                return (string)GetValue(ButtonTitleProperty);
            }

            set
            {
                SetValue(ButtonTitleProperty, value);
            }
        }

        public string ButtonActionOne
        {
            get
            {
                return (string)GetValue(ButtonActionOneProperty);
            }

            set
            {
                SetValue(ButtonActionOneProperty, value);
            }
        }

        public string ButtonActionTwo
        {
            get
            {
                return (string)GetValue(ButtonActionTwoProperty);
            }

            set
            {
                SetValue(ButtonActionTwoProperty, value);
            }
        }
        #endregion

        #region Methoods
        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == TitleProperty.PropertyName)
            {
                title.Text = Title;
            }
            else if (propertyName == ImgCardProperty.PropertyName)
            {
                imgCard.Source = ImgCard;
            }
            else if (propertyName == ShortDescriptProperty.PropertyName)
            {
                shortDescript.Text = ShortDescript;
            }
            else if (propertyName == ButtonTitleProperty.PropertyName)
            {
                buttonTitle.Text = ButtonTitle;
            }
            else if (propertyName == ButtonActionOneProperty.PropertyName)
            {
                buttonActionOne.Text = ButtonActionOne;
            }
            else if (propertyName == ButtonActionTwoProperty.PropertyName)
            {
                buttonActionTwo.Text = ButtonActionTwo;
            }
            else if (propertyName == ImgCardPropertyLocalSource.PropertyName)
            {
               imgCard.Source = ImgCardLocalSource;
            }
        }


     
        #endregion

        public CardView()
        {
            InitializeComponent();
            title.Text = Title;
            //mgCard.Source = ImgCardLocalSource;
            shortDescript.Text = ShortDescript;
            buttonTitle.Text = ButtonTitle;
            buttonActionOne.Text = ButtonActionOne;
            buttonActionTwo.Text = ButtonActionTwo;
        }

    } // endClass 
}
