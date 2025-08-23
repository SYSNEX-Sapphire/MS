using CommunityToolkit.Mvvm.ComponentModel;
using CsvHelper.Configuration.Attributes;
using System.Collections;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Media;

namespace SapphireXR_App.Models
{
    public partial class Recipe : ObservableObject
    {
        public Recipe() { }

        public Recipe(Recipe rhs)
        {
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

        public string Name { get; set; } = "";
        // RecipeInt Array
        [ObservableProperty]
        public short no;
        [ObservableProperty]
        private short _rTime;
        [ObservableProperty]
        public short _hTime;
        [ObservableProperty]
        public short _sTemp;
        [ObservableProperty]
        public short _rPress;
        [ObservableProperty]
        public short _sRotation;
        public short cTemp { get; set; }
        public short LoopRepeat { get; set; }
        public short LoopEndStep { get; set; }
        //RecipeFloat Array
        [ObservableProperty]
        private float _m01;
        [ObservableProperty]
        private float _m02;
        [ObservableProperty]
        private float _m03;
        [ObservableProperty]
        private float _m04;
        [ObservableProperty]
        private float _m05;
        [ObservableProperty]
        private float _m06;
        [ObservableProperty]
        private float _m07;
        [ObservableProperty]
        private float _m08;
        [ObservableProperty]
        private float _m09;
        [ObservableProperty]
        private float _m10;
        [ObservableProperty]
        private float _m11;
        [ObservableProperty]
        private float _m12;
        [ObservableProperty]
        private float _e01;
        [ObservableProperty]
        private float _e02;
        [ObservableProperty]
        private float _e03;
        [ObservableProperty]
        private float _e04;
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
            aRecipeShort[3] = rhs.STemp;
            aRecipeShort[4] = rhs.RPress;
            aRecipeShort[5] = rhs.SRotation;
            aRecipeShort[6] = rhs.cTemp;
            aRecipeShort[7] = rhs.JumpStride;
            aRecipeShort[8] = rhs.LoopCount;
            //Float Type Array
            aRecipeFloat[0] = rhs.M01;
            aRecipeFloat[1] = rhs.M02;
            aRecipeFloat[2] = rhs.M03;
            aRecipeFloat[3] = rhs.M04;
            aRecipeFloat[4] = rhs.M05;
            aRecipeFloat[5] = rhs.M06;
            aRecipeFloat[6] = rhs.M07;
            aRecipeFloat[7] = rhs.M08;
            aRecipeFloat[8] = rhs.M09;
            aRecipeFloat[9] = rhs.M10;
            aRecipeFloat[10] = rhs.M11;
            aRecipeFloat[11] = rhs.M12;
            aRecipeFloat[19] = rhs.E01;
            aRecipeFloat[20] = rhs.E02;
            aRecipeFloat[21] = rhs.E03;
            aRecipeFloat[22] = rhs.E04;
            //BitArray from Valve Data
            BitArray aRecipeBit = new BitArray(32);
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

            sName = rhs.Name;

            if (aRecipeBit.Length > 32)
                throw new ArgumentException("Argument length shall be at most 32 bits.");
            int[] aValve = new int[1];
            aRecipeBit.CopyTo(aValve, 0);
            iValve = aValve[0];
        }

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
        public string sName = "";

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
        public short[] aRecipeShort = new short[9];

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 26)]
        public float[] aRecipeFloat = new float[26];

        public int iValve;
    }
}
