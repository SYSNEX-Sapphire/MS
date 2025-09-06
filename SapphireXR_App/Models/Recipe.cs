using CommunityToolkit.Mvvm.ComponentModel;
using CsvHelper.Configuration.Attributes;
using SapphireXR_App.Common;
using SapphireXR_App.ViewModels;
using System.Collections;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Media;

namespace SapphireXR_App.Models
{
    public partial class Recipe : ObservableObject
    {
        public Recipe() 
        {
            initialize();
        }

        public Recipe(Recipe rhs)
        {
            initialize();

            No = rhs.No;
            Name = rhs.Name;
            cTemp = rhs.cTemp;
            HTime = rhs.HTime;
            LoopEndStep = rhs.LoopEndStep;
            RPress = rhs.RPress;
            SRotation = rhs.SRotation;
            LoopRepeat = rhs.LoopRepeat;
            RTime = rhs.RTime;
            STemp = rhs.STemp;
            E01 = rhs.E01;
            E02 = rhs.E02;
            E03 = rhs.E03;
            E04 = rhs.E04;
            M01 = rhs.M01;
            M02 = rhs.M02;
            M03 = rhs.M03;
            M04 = rhs.M04;
            M05 = rhs.M05;
            M06 = rhs.M06;
            M07 = rhs.M07;
            M08 = rhs.M08;
            M09 = rhs.M09;
            M10 = rhs.M10;
            M11 = rhs.M11;
            M12 = rhs.M12;
            V01 = rhs.V01;
            V02 = rhs.V02;
            V03 = rhs.V03;
            V04 = rhs.V04;
            V05 = rhs.V05;
            V06 = rhs.V06;
            V07 = rhs.V07;
            V08 = rhs.V08;
            V09 = rhs.V09;
            V10 = rhs.V10;
            V11 = rhs.V11;
            V12 = rhs.V12;
            V13 = rhs.V13;
            V14 = rhs.V14;
            V15 = rhs.V15;
            V16 = rhs.V16;
            V17 = rhs.V17;
            V18 = rhs.V18;
            V19 = rhs.V19;
            V20 = rhs.V20;
        }

        private void initialize()
        {
            PropertyChanged += (sender, args) =>
            {
                var constraintValue = (string fullName, float? curValue) =>
                {
                    if (curValue == null)
                    {
                        return curValue;
                    }

                    int? maxValue = SettingViewModel.ReadMaxValue(fullName) ?? 0;
                    if (maxValue < curValue)
                    {
                        maxValueExceedPublihser.Publish(fullName);
                        return (float)maxValue;
                    }
                    else
                    {
                        return curValue;
                    }
                };
                switch(args.PropertyName)
                {
                    case nameof(M01):
                        M01 = constraintValue("MFC01", M01);
                        break;

                    case nameof(M02):
                        M02 = constraintValue("MFC02", M02);
                        break;

                    case nameof(M03):
                        M03 = constraintValue("MFC03", M03);
                        break;

                    case nameof(M04):
                        M04 = constraintValue("MFC04", M04);
                        break;

                    case nameof(M05):
                        M05 = constraintValue("MFC05", M05);
                        break;

                    case nameof(M06):
                        M06 = constraintValue("MFC06", M06);
                        break;

                    case nameof(M07):
                        M07 = constraintValue("MFC07", M07);
                        break;

                    case nameof(M08):
                        M08 = constraintValue("MFC08", M08);
                        break;

                    case nameof(M09):
                        M09 = constraintValue("MFC09", M09);
                        break;

                    case nameof(M10):
                        M10 = constraintValue("MFC10", M10);
                        break;

                    case nameof(M11):
                        M11 = constraintValue("MFC11", M11);
                        break;

                    case nameof(M12):
                        M12 = constraintValue("MFC12", M12);
                        break;

                    case nameof(E01):
                        E01 = constraintValue("EPC01", E01);
                        break;

                    case nameof(E02):
                        E02 = constraintValue("EPC02", E02);
                        break;

                    case nameof(E03):
                        E03 = constraintValue("EPC03", E03);
                        break;

                    case nameof(E04):
                        E04 = constraintValue("EPC04", E04);
                        break;

                    case nameof(STemp):
                        STemp = constraintValue("Temperature", STemp);
                        break;

                    case nameof(RPress):
                        RPress = constraintValue("Pressure", RPress);
                        break;

                    case nameof(SRotation):
                        SRotation = constraintValue("Rotation", SRotation);
                        break;

                    case nameof(LoopRepeat):
                        if(LoopRepeat == null)
                        {
                            LoopEndStep = null;
                        }
                        break;

                    case nameof(LoopEndStep):
                        if(LoopEndStep == null)
                        {
                            LoopRepeat = null;
                        }
                        break;
                }
            };
        }

        public string Name { get; set; } = "";
        // RecipeInt Array
        [ObservableProperty]
        public short no;
        [ObservableProperty]
        private short _rTime;
        [ObservableProperty]
        public short _hTime;
        [ObservableProperty]
        public float? _sTemp;
        [ObservableProperty]
        public float? _rPress;
        [ObservableProperty]
        public float? _sRotation;
        [ObservableProperty]
        public float? cTemp;
        [ObservableProperty]
        public short? loopRepeat;
        [ObservableProperty]
        public short? loopEndStep;
        //RecipeFloat Array
        [ObservableProperty]
        private float? _m01;
        [ObservableProperty]
        private float? _m02;
        [ObservableProperty]
        private float? _m03;
        [ObservableProperty]
        private float? _m04;
        [ObservableProperty]
        private float? _m05;
        [ObservableProperty]
        private float? _m06;
        [ObservableProperty]
        private float? _m07;
        [ObservableProperty]
        private float? _m08;
        [ObservableProperty]
        private float? _m09;
        [ObservableProperty]
        private float? _m10;
        [ObservableProperty]
        private float? _m11;
        [ObservableProperty]
        private float? _m12;
        [ObservableProperty]
        private float? _e01;
        [ObservableProperty]
        private float? _e02;
        [ObservableProperty]
        private float? _e03;
        [ObservableProperty]
        private float? _e04;
        //RecipeDouble Array
        [ObservableProperty]
        private bool _v01;
        [ObservableProperty]
        private bool _v02;
        [ObservableProperty]
        private bool _v03;
        [ObservableProperty]
        private bool _v04;
        [ObservableProperty]
        private bool _v05;  //TEB
        [ObservableProperty]
        private bool _v06;  //TEB
        [ObservableProperty]
        private bool _v07;
        [ObservableProperty]
        private bool _v08; //TMAl
        [ObservableProperty]
        private bool _v09;  //TEB
        [ObservableProperty]
        private bool _v10;
        [ObservableProperty]
        private bool _v11; //TMIn
        [ObservableProperty]
        private bool _v12;  //TEB
        [ObservableProperty]
        private bool _v13;
        [ObservableProperty]
        private bool _v14; //TMGa
        [ObservableProperty]
        private bool _v15;  //TEB
        [ObservableProperty]
        private bool _v16;
        [ObservableProperty]
        private bool _v17; //DTMGa
        [ObservableProperty]
        private bool _v18;  //TEB
        [ObservableProperty]
        private bool _v19;
        [ObservableProperty]
        private bool _v20; //Cp2Mg

        public static readonly Brush DefaultBackground = Application.Current.FindResource("DefaultRecipeListBackground") as Brush ?? new SolidColorBrush(Color.FromRgb(0x16, 0x16, 0x16));
        public static readonly Brush DefaultForeground = Application.Current.FindResource("DefaultRecipeListForeground") as Brush ?? new SolidColorBrush(Color.FromRgb(0xC2, 0xC2, 0xC2));

        Brush _background = DefaultBackground;
        [Ignore]
        public Brush Background
        {
            get { return _background; }
            set { SetProperty(ref _background, value); }
        }

        bool _isEnabled = true;
        [Ignore]
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set { SetProperty(ref _isEnabled, value); }
        }

        Brush _foreground = DefaultForeground;
        [Ignore]
        public Brush Foreground
        {
            get { return _foreground;  }
            set { SetProperty(ref _foreground, value);  }
        }

        [Ignore]
        public short JumpStride
        {
            set;
            get;
        } = 0;

        [Ignore]
        public short LoopCount
        {
            set;
            get;
        } = 0;

        [Ignore]
        private static readonly ObservableManager<string>.Publisher maxValueExceedPublihser = ObservableManager<string>.Get("Recipe.MaxValueExceed");
    }

    [StructLayout(LayoutKind.Sequential, Pack = 0)]
    public class PlcRecipe
    {
        public PlcRecipe(Recipe rhs)
        {
            //Short Type Array
            aRecipeShort[0] = rhs.No;
            aRecipeShort[1] = rhs.RTime;
            aRecipeShort[2] = rhs.HTime;
            aRecipeShort[3] = rhs.JumpStride;
            aRecipeShort[4] = rhs.LoopCount;
            //Float Type Array
            aRecipeFloat[0] = rhs.M01 ?? -1.0f;
            aRecipeFloat[1] = rhs.M02 ?? -1.0f;
            aRecipeFloat[2] = rhs.M03 ?? -1.0f;
            aRecipeFloat[3] = rhs.M04 ?? -1.0f;
            aRecipeFloat[4] = rhs.M05 ?? -1.0f;
            aRecipeFloat[5] = rhs.M06 ?? -1.0f;
            aRecipeFloat[6] = rhs.M07 ?? -1.0f;
            aRecipeFloat[7] = rhs.M08 ?? -1.0f;
            aRecipeFloat[8] = rhs.M09 ?? -1.0f;
            aRecipeFloat[9] = rhs.M10 ?? -1.0f;
            aRecipeFloat[10] = rhs.M11 ?? -1.0f;
            aRecipeFloat[11] = rhs.M12 ?? -1.0f;
            aRecipeFloat[12] = rhs.E01 ?? -1.0f;
            aRecipeFloat[13] = rhs.E02 ?? -1.0f;
            aRecipeFloat[14] = rhs.E03 ?? -1.0f;
            aRecipeFloat[15] = rhs.E04 ?? -1.0f;
            aRecipeFloat[16] = rhs.STemp ?? -1.0f;
            aRecipeFloat[17] = rhs.RPress ?? -1.0f;
            aRecipeFloat[18] = rhs.SRotation ?? -1.0f;
            
            cTemp = rhs.CTemp ?? 0;

            //BitArray from Valve Data
            BitArray aRecipeBit = new(32);
            aRecipeBit[0] = rhs.V01;
            aRecipeBit[1] = rhs.V02;
            aRecipeBit[2] = rhs.V03;
            aRecipeBit[3] = rhs.V04;
            aRecipeBit[4] = rhs.V05;
            aRecipeBit[5] = rhs.V06;
            aRecipeBit[6] = rhs.V07;
            aRecipeBit[7] = rhs.V08;
            aRecipeBit[8] = rhs.V09;
            aRecipeBit[9] = rhs.V10;
            aRecipeBit[10] = rhs.V11;
            aRecipeBit[11] = rhs.V12;
            aRecipeBit[12] = rhs.V13;
            aRecipeBit[13] = rhs.V14;
            aRecipeBit[14] = rhs.V15;
            aRecipeBit[15] = rhs.V16;
            aRecipeBit[16] = rhs.V17;
            aRecipeBit[17] = rhs.V18;
            aRecipeBit[18] = rhs.V19;
            aRecipeBit[19] = rhs.V20;
            
            int[] aValve = new int[1];
            aRecipeBit.CopyTo(aValve, 0);
            iValve = aValve[0];

            sName = rhs.Name;
        }

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
        public string sName = "";

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public short[] aRecipeShort = new short[5];

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 19)]
        public float[] aRecipeFloat = new float[19];

        public float cTemp;
        public int iValve;
    }
}
