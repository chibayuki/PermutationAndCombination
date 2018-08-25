/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
Copyright © 2018 chibayuki@foxmail.com

排列组合 (PermutationAndCombination)
Version 18.8.12.0000

This file is part of "排列组合" (PermutationAndCombination)

"排列组合" (PermutationAndCombination) is released under the GPLv3 license
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;
using System.Text.RegularExpressions;

namespace WinFormApp
{
    public partial class Form_Main : Form
    {
        #region 版本信息

        private static readonly string ApplicationName = Application.ProductName; // 程序名。
        private static readonly string ApplicationEdition = "18"; // 程序版本。

        private static readonly Int32 MajorVersion = new Version(Application.ProductVersion).Major; // 主版本。
        private static readonly Int32 MinorVersion = new Version(Application.ProductVersion).Minor; // 副版本。
        private static readonly Int32 BuildNumber = new Version(Application.ProductVersion).Build; // 版本号。
        private static readonly Int32 BuildRevision = new Version(Application.ProductVersion).Revision; // 修订版本。
        private static readonly string LabString = "REL"; // 分支名。
        private static readonly string BuildTime = "180812-0000"; // 编译时间。

        #endregion

        #region 程序功能变量

        private struct SciN // 科学计数法。
        {
            public double Val; // 有效数字。
            public Int64 Exp; // 数量级。
        }

        private double Total_Input = 0; // 输入的总数。
        private double Selection_Input = 0; // 输入的选取数。

        private Color FocusedColor; // 指定日期标签获得焦点时的背景色。
        private Color PointedColor; // 指定日期标签被指向但未获得焦点时的背景色。
        private Color UnfocusedColor; // 指定日期标签失去焦点时的背景色。

        #endregion

        #region 窗体构造

        private Com.WinForm.FormManager Me;

        public Com.WinForm.FormManager FormManager
        {
            get
            {
                return Me;
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_MINIMIZEBOX = 0x00020000;

                CreateParams CP = base.CreateParams;

                if (Me != null && Me.FormStyle != Com.WinForm.FormStyle.Dialog)
                {
                    CP.Style = CP.Style | WS_MINIMIZEBOX;
                }

                return CP;
            }
        }

        private void _Ctor(Com.WinForm.FormManager owner)
        {
            InitializeComponent();

            //

            if (owner != null)
            {
                Me = new Com.WinForm.FormManager(this, owner);
            }
            else
            {
                Me = new Com.WinForm.FormManager(this);
            }

            //

            FormDefine();
        }

        public Form_Main()
        {
            _Ctor(null);
        }

        public Form_Main(Com.WinForm.FormManager owner)
        {
            _Ctor(owner);
        }

        private void FormDefine()
        {
            Me.Caption = Application.ProductName;
            Me.FormStyle = Com.WinForm.FormStyle.Fixed;
            Me.EnableFullScreen = false;
            Me.ClientSize = new Size(450, 225);
            Me.Theme = Com.WinForm.Theme.Colorful;
            Me.ThemeColor = Com.ColorManipulation.GetRandomColorX();
            Me.FormState = Com.WinForm.FormState.Maximized;

            Me.Loaded += LoadedEvents;
            Me.Closed += ClosedEvents;
            Me.SizeChanged += SizeChangedEvents;
            Me.ThemeChanged += ThemeColorChangedEvents;
            Me.ThemeColorChanged += ThemeColorChangedEvents;
        }

        #endregion

        #region 窗体事件

        private void LoadedEvents(object sender, EventArgs e)
        {
            //
            // 在窗体加载后发生。
            //

            Me.OnThemeChanged();

            //

            NowArrangement = true;

            //

            ReturnToZero();
        }

        private void ClosedEvents(object sender, EventArgs e)
        {
            //
            // 在窗体关闭后发生。
            //

            Calc_Stop();
        }

        private void SizeChangedEvents(object sender, EventArgs e)
        {
            //
            // 在窗体的大小更改时发生。
            //

            Panel_Client.Size = Panel_Main.Size;

            //

            Panel_ArrangementAndCombination.Refresh();
        }

        private void ThemeColorChangedEvents(object sender, EventArgs e)
        {
            //
            // 在窗体的主题色更改时发生。
            //

            FocusedColor = Me.RecommendColors.Background_INC.ToColor();
            PointedColor = Me.RecommendColors.Background.ToColor();
            UnfocusedColor = Color.Transparent;

            //

            Label_AppName.ForeColor = Me.RecommendColors.Text.ToColor();
            Label_Note.ForeColor = Me.RecommendColors.Text_DEC.ToColor();

            //

            Label_ReturnToZero.ForeColor = Me.RecommendColors.Text.ToColor();
            Label_ReturnToZero.BackColor = Me.RecommendColors.Background_DEC.ToColor();

            Panel_Input.BackColor = Panel_Output.BackColor = Me.RecommendColors.Background_DEC.ToColor();

            Label_AC.ForeColor = Label_Total.ForeColor = Label_Selection.ForeColor = Me.RecommendColors.Text.ToColor();
            Label_Equal.ForeColor = Label_Val.ForeColor = Label_Exp.ForeColor = Me.RecommendColors.Text.ToColor();

            Label_Time.ForeColor = (Me.RecommendColors.Main.Lightness_LAB < 70 ? Color.White : Color.Black);
            Label_Time.BackColor = Me.RecommendColors.Main.ToColor();

            ContextMenuStrip_Total.BackColor = Me.RecommendColors.MenuItemBackground.ToColor();
            ToolStripMenuItem_Total_Copy.ForeColor = ToolStripMenuItem_Total_Paste.ForeColor = Me.RecommendColors.MenuItemText.ToColor();

            ContextMenuStrip_Selection.BackColor = Me.RecommendColors.MenuItemBackground.ToColor();
            ToolStripMenuItem_Selection_Copy.ForeColor = ToolStripMenuItem_Selection_Paste.ForeColor = Me.RecommendColors.MenuItemText.ToColor();

            ContextMenuStrip_Output.BackColor = Me.RecommendColors.MenuItemBackground.ToColor();
            ToolStripMenuItem_Output_Copy.ForeColor = Me.RecommendColors.MenuItemText.ToColor();

            //

            Com.WinForm.ControlSubstitution.LabelAsButton(Label_ReturnToZero, Label_ReturnToZero_Click, Me.RecommendColors.Background_DEC.ToColor(), PointedColor, FocusedColor);
            Com.WinForm.ControlSubstitution.LabelAsButton(Label_AC, Label_AC_Click, UnfocusedColor, PointedColor, FocusedColor);
        }

        #endregion

        #region 背景绘图

        private void Panel_ArrangementAndCombination_Paint(object sender, PaintEventArgs e)
        {
            //
            // Panel_ArrangementAndCombination 绘图。
            //

            Pen BorderLine = new Pen(Me.RecommendColors.Border_DEC.ToColor(), 1);
            Pen BorderLine_Shadow = new Pen(Me.RecommendColors.Border_DEC.AtAlpha(96).ToColor(), 1);

            e.Graphics.DrawRectangle(BorderLine_Shadow, Com.Geometry.GetMinimumBoundingRectangleOfControls(new Control[] { Label_ReturnToZero }, 3));
            e.Graphics.DrawRectangle(BorderLine, Com.Geometry.GetMinimumBoundingRectangleOfControls(new Control[] { Label_ReturnToZero }, 2));

            e.Graphics.DrawRectangle(BorderLine_Shadow, Com.Geometry.GetMinimumBoundingRectangleOfControls(new Control[] { Panel_Input, Panel_Output }, 3));
            e.Graphics.DrawRectangle(BorderLine, Com.Geometry.GetMinimumBoundingRectangleOfControls(new Control[] { Panel_Input, Panel_Output }, 2));
        }

        #endregion

        #region 排列组合函数

        private SciN RecursionForGamma(double V)
        {
            //
            // 伽玛函数的递归函数。对于 0 或正实数 V，计算 V * (V - 1) * (V - 2) * ... * (V - Math.Floor(V)) 的值。
            //

            if (BackgroundWorker_Calc != null && BackgroundWorker_Calc.CancellationPending)
            {
                return new SciN();
            }

            //

            SciN SN = new SciN();

            double Vx = V - Math.Floor(V);

            if (V < 1)
            {
                SN.Val = V;
                SN.Exp = 0;
            }
            else if (V < 2)
            {
                SN.Val = V * Vx;
                SN.Exp = 0;
            }
            else
            {
                Int64 Vm = (Int64)Math.Pow(10, Math.Floor(Math.Log10(V)));

                if (Vm == V - Vx)
                {
                    Vm /= 10;
                }

                SciN RGx = RecursionForGamma(Vm + Vx);

                SN.Val = RGx.Val;
                SN.Exp = RGx.Exp + (Int64)(Math.Log10(Vm) * (V - Vx - Vm));

                for (double i = Vm + Vx + 1; i <= V; i++)
                {
                    if (BackgroundWorker_Calc != null && BackgroundWorker_Calc.CancellationPending)
                    {
                        return new SciN();
                    }

                    if ((Int64)i % 1048576 == 0 && LastReportProgressToNow.TotalMilliseconds >= 1000)
                    {
                        ReportRemainingTime(i);
                    }

                    //

                    SN.Val *= (i / Vm);

                    if (SN.Val >= 10)
                    {
                        SN.Val /= 10;
                        SN.Exp++;
                    }
                }
            }

            return SN;
        }

        private static readonly double[] Coeff = new double[] { 0.99999999999980993, 676.5203681218851, -1259.1392167224028, 771.32342877765313, -176.61502916214059, 12.507343278686905, -0.13857109526572012, 9.9843695780195716E-6, 1.5056327351493116E-7 }; // 切比雪夫多项式系数。

        private SciN Gamma(double V)
        {
            //
            // 伽玛函数。计算 -1E14 + 0.1 至 1E14 - 0.1 之间的小数的阶乘。
            //

            if (BackgroundWorker_Calc != null && BackgroundWorker_Calc.CancellationPending)
            {
                return new SciN();
            }

            //

            SciN SN = new SciN();

            if (V <= 0) // 欧拉反射公式。计算小于 0 的小数的伽玛值。
            {
                SciN R = Gamma(1 - V);

                if (R.Val == 0)
                {
                    SN.Val = 0;
                    SN.Exp = 0;
                }
                else
                {
                    SN.Val = Math.PI / (Math.Sin(Math.PI * V) * R.Val);
                    SN.Exp = -R.Exp;

                    while (SN.Val <= -10 || SN.Val >= 10)
                    {
                        SN.Val /= 10;
                        SN.Exp++;
                    }

                    if (SN.Val == 0)
                    {
                        SN.Exp = 0;
                    }
                    else
                    {
                        while (SN.Val > -1 && SN.Val < 1)
                        {
                            SN.Val *= 10;
                            SN.Exp--;
                        }
                    }
                }
            }
            else if (V > 0 && V <= 1) // 切比雪夫算法。计算 0 到 1 之间的小数的伽玛值。
            {
                double Sum = Coeff[0];

                V--;

                for (int i = 1; i < Coeff.Count(); i++)
                {
                    if (BackgroundWorker_Calc != null && BackgroundWorker_Calc.CancellationPending)
                    {
                        return new SciN();
                    }

                    Sum += Coeff[i] / (V + i);
                }

                double Base = V + 0.5 + (Coeff.Count() - 2);

                SN.Val = Math.Sqrt(2 * Math.PI) * Math.Pow(Base, V + 0.5) * Math.Exp(-Base) * Sum;
                SN.Exp = 0;

                while (SN.Val >= 10)
                {
                    SN.Val /= 10;
                    SN.Exp++;
                }
            }
            else // 递推公式。计算大于 1 的小数的伽玛值。
            {
                SciN RG = RecursionForGamma(V - 1);

                SN.Val = RG.Val;
                SN.Exp = RG.Exp;

                double Vx = V - Math.Truncate(V);

                SciN R = Gamma(Vx);

                SN.Val *= R.Val;
                SN.Exp += R.Exp;

                while (SN.Val >= 10)
                {
                    SN.Val /= 10;
                    SN.Exp++;
                }
            }

            return SN;
        }

        private SciN Stirling(double V)
        {
            //
            // 斯特林公式。计算 0 至 1E15 - 1 之间的实数的阶乘的近似值。
            //

            if (BackgroundWorker_Calc != null && BackgroundWorker_Calc.CancellationPending)
            {
                return new SciN();
            }

            //

            SciN SN = new SciN();

            if (V >= 0) // 计算 0 与正数的阶乘。
            {
                Int64 V_Exp;
                double V_Val;

                if (V == 0)
                {
                    V_Exp = 0;
                    V_Val = 0;
                }
                else
                {
                    V_Exp = (Int64)Math.Floor(Math.Log10(V));
                    V_Val = V / Math.Pow(10, V_Exp);

                    if (V_Val == 0)
                    {
                        V_Exp = 0;
                    }
                    else
                    {
                        if (V_Val < 1)
                        {
                            V_Val *= 10;
                            V_Exp--;
                        }
                    }
                }

                if (V_Exp <= 14) // 斯特林公式。计算 0 至 1E15 - 1 的阶乘。
                {
                    if (V == 0 || V == 1) // 计算 0 或 1 的阶乘。
                    {
                        SN.Val = 1;
                        SN.Exp = 0;
                    } // 计算 0 或 1 的阶乘。
                    else
                    {
                        double FR_Val_F = 0; // 阶乘结果的底数。
                        decimal FR_Exp_M = 0; // 阶乘结果的指数（十进制数）。

                        double XdivE_Val = V_Val / Math.E;
                        decimal XdivE_Exp = V_Exp;

                        if (XdivE_Val == 0)
                        {
                            XdivE_Exp = 0;
                        }
                        else
                        {
                            if (XdivE_Val < 1)
                            {
                                XdivE_Val *= 10;
                                XdivE_Exp--;
                            }
                        }

                        FR_Val_F = Math.Pow(XdivE_Val, V_Val);
                        FR_Exp_M = XdivE_Exp * (decimal)V_Val * (decimal)Math.Pow(10, V_Exp);

                        decimal ExpTmp = 0;

                        for (long i = 1; i <= V_Exp; i++)
                        {
                            if (BackgroundWorker_Calc != null && BackgroundWorker_Calc.CancellationPending)
                            {
                                return new SciN();
                            }

                            ExpTmp *= 10;
                            FR_Val_F = Math.Pow(FR_Val_F, 10);
                            ExpTmp += (decimal)Math.Floor(Math.Log10(FR_Val_F));
                            FR_Val_F /= Math.Pow(10, Math.Floor(Math.Log10(FR_Val_F)));
                        }

                        FR_Exp_M += ExpTmp;
                        FR_Exp_M += (decimal)(0.5 * V_Exp);

                        double Sq2PiX = Math.Sqrt(2 * Math.PI * V_Val);

                        FR_Val_F *= Sq2PiX * Math.Pow(10, (double)(FR_Exp_M - Math.Floor(FR_Exp_M)));
                        FR_Exp_M = Math.Floor(FR_Exp_M);

                        while (FR_Val_F >= 10)
                        {
                            FR_Val_F /= 10;
                            FR_Exp_M++;
                        }

                        SN.Val = FR_Val_F;
                        SN.Exp = (Int64)Math.Round(FR_Exp_M);
                    }
                } // 斯特林公式。计算 0 至 1E15 - 1 的阶乘。
                else
                {
                    SN.Val = double.PositiveInfinity;
                }
            }
            else
            {
                SN.Val = double.NaN;
            }

            return SN;
        }

        private SciN RecursionForFactorial(Int64 L)
        {
            //
            // 阶乘函数的递归函数。计算 1 至 1E15 - 1 之间的整数的阶乘。
            //

            if (BackgroundWorker_Calc != null && BackgroundWorker_Calc.CancellationPending)
            {
                return new SciN();
            }

            //

            SciN SN = new SciN();

            if (L == 1)
            {
                SN.Val = 1;
                SN.Exp = 0;
            }
            else
            {
                Int64 Lv = (Int64)Math.Pow(10, Math.Floor(Math.Log10(L)));

                if (Lv == L)
                {
                    Lv /= 10;
                }

                SciN RFx = RecursionForFactorial(Lv);

                SN.Val = RFx.Val;
                SN.Exp = RFx.Exp + (Int64)Math.Log10(Lv) * (L - Lv);

                for (double i = Lv + 1; i <= L; i++)
                {
                    if (BackgroundWorker_Calc != null && BackgroundWorker_Calc.CancellationPending)
                    {
                        return new SciN();
                    }

                    if ((Int64)i % 1048576 == 0 && LastReportProgressToNow.TotalMilliseconds >= 1000)
                    {
                        ReportRemainingTime(i);
                    }

                    //

                    SN.Val *= (i / Lv);

                    if (SN.Val >= 10)
                    {
                        SN.Val /= 10;
                        SN.Exp++;
                    }
                }
            }

            return SN;
        }

        private SciN Factorial(double V)
        {
            //
            // 阶乘函数。
            //

            if (BackgroundWorker_Calc != null && BackgroundWorker_Calc.CancellationPending)
            {
                return new SciN();
            }

            //

            SciN SN = new SciN();

            if (V == Math.Truncate(V)) // 计算整数的阶乘。
            {
                if (V >= 0) // 计算 0 与正整数的阶乘。
                {
                    if (V < 1E15) // 计算 0 至 1E15 - 1 的阶乘。
                    {
                        Int64 V_L = (Int64)V;

                        if (V_L == 0 || V_L == 1) // 计算 0 或 1 的阶乘。
                        {
                            SN.Val = 1;
                            SN.Exp = 0;
                        } // 计算 0 或 1 的阶乘。
                        else if (V_L <= 20) // 计算 2 至 20 的阶乘。
                        {
                            double FR_Val_F = 1;
                            Int64 FR_Exp_L = 0;

                            for (long i = 1; i <= V_L; i++)
                            {
                                if (BackgroundWorker_Calc != null && BackgroundWorker_Calc.CancellationPending)
                                {
                                    return new SciN();
                                }

                                FR_Val_F *= i;
                            }

                            while (FR_Val_F >= 10)
                            {
                                FR_Val_F /= 10;
                                FR_Exp_L++;
                            }

                            SN.Val = FR_Val_F;
                            SN.Exp = FR_Exp_L;
                        } // 计算 2 至 20 的阶乘。
                        else // 调用 RecursionForFactorial 函数。计算 21 至 1E15 - 1 的阶乘。
                        {
                            SN = RecursionForFactorial(V_L);
                        } // 调用 RecursionForFactorial 函数。计算 21 至 1E15 - 1 的阶乘。
                    } // 计算 0 至 1E15 - 1 的阶乘。
                    else
                    {
                        SN.Val = double.PositiveInfinity;
                        SN.Exp = 0;
                    }
                } // 计算正整数的阶乘。
                else // 计算负整数的阶乘。
                {
                    SN.Val = double.PositiveInfinity;
                    SN.Exp = 0;
                } // 计算负整数的阶乘。
            } // 计算整数的阶乘。
            else // 计算小数的阶乘。
            {
                if (Math.Abs(V) < 1E15) // 调用 Gamma 函数。计算 -1E14 + 0.1 至 1E14 - 0.1 之间的小数的阶乘。
                {
                    SN = Gamma(V + 1);
                } // 调用 Gamma 函数。计算 -1E14 + 0.1 至 1E14 - 0.1 之间的小数的阶乘。
                else
                {
                    SN.Val = double.PositiveInfinity;
                    SN.Exp = 0;
                }
            } // 计算小数的阶乘。

            return SN;
        }

        private struct ACRslt // 排列组合函数的计算结果。
        {
            public string ValStr; // 底数的字符串。
            public string ExpStr; // 指数的字符串。
            public bool IsExactValue; // 此计算结果是（true）否为准确值。
        }

        private SciN SciNDivision(SciN Left, SciN Right)
        {
            //
            // 科学计数法除法。
            //

            SciN Result = new SciN();

            if (double.IsNaN(Left.Val) || double.IsNaN(Right.Val))
            {
                Result.Val = double.NaN;
                Result.Exp = 0;
            }
            else if (double.IsInfinity(Left.Val) || double.IsInfinity(Right.Val))
            {
                if (double.IsInfinity(Left.Val) && double.IsInfinity(Right.Val))
                {
                    Result.Val = double.NaN;
                }
                else if (double.IsPositiveInfinity(Left.Val))
                {
                    Result.Val = double.PositiveInfinity;
                }
                else if (double.IsNegativeInfinity(Left.Val))
                {
                    Result.Val = double.NegativeInfinity;
                }
                else
                {
                    Result.Val = 0;
                }

                Result.Exp = 0;
            }
            else if (Left.Val == 0 || Right.Val == 0)
            {
                if (Left.Val == 0 && Right.Val == 0)
                {
                    Result.Val = double.NaN;
                    Result.Exp = 0;
                }
                else if (Left.Val == 0)
                {
                    Result.Val = 0;
                    Result.Exp = 0;
                }
                else if (Left.Val > 0)
                {
                    Result.Val = double.PositiveInfinity;
                    Result.Exp = 0;
                }
                else
                {
                    Result.Val = double.NegativeInfinity;
                    Result.Exp = 0;
                }
            }
            else
            {
                if ((double)Left.Exp - Right.Exp > Int64.MaxValue)
                {
                    Result.Val = double.PositiveInfinity;
                    Result.Exp = 0;
                }
                else if ((double)Left.Exp - Right.Exp < Int64.MinValue)
                {
                    Result.Val = 0;
                    Result.Exp = 0;
                }
                else
                {
                    Result.Val = Left.Val / Right.Val;
                    Result.Exp = Left.Exp - Right.Exp;
                }

                if (!double.IsNaN(Result.Val) && !double.IsInfinity(Result.Val))
                {
                    while (Result.Val <= -10 || Result.Val >= 10)
                    {
                        Result.Val /= 10;
                        Result.Exp++;
                    }

                    if (Result.Val == 0)
                    {
                        Result.Exp = 0;
                    }
                    else
                    {
                        while (Result.Val > -1 && Result.Val < 1)
                        {
                            Result.Val *= 10;
                            Result.Exp--;
                        }
                    }
                }
            }

            return Result;
        }

        private ACRslt Arrangement(double Total, double Selection)
        {
            //
            // 排列函数。
            //

            if (BackgroundWorker_Calc != null && BackgroundWorker_Calc.CancellationPending)
            {
                return new ACRslt();
            }

            //

            ACRslt AR = new ACRslt();
            AR.IsExactValue = true;

            SciN Fact_T = Factorial(Total);
            CycDone = 1;

            SciN Fact_TsubS = Factorial(Total - Selection);
            CycDone = 2;

            SciN SN_AR = SciNDivision(Fact_T, Fact_TsubS);

            if (double.IsNaN(SN_AR.Val))
            {
                AR.ValStr = "非数字";
            }
            else if (double.IsInfinity(SN_AR.Val))
            {
                AR.ValStr = "溢出";
            }
            else
            {
                if (SN_AR.Exp >= 15 || SN_AR.Exp <= -5)
                {
                    AR.ValStr = SN_AR.Val + " × 10";
                    AR.ExpStr = SN_AR.Exp.ToString();
                }
                else
                {
                    AR.ValStr = (SN_AR.Val * Math.Pow(10, SN_AR.Exp)).ToString();
                }
            }

            return AR;
        }

        private ACRslt Arrangement_Approx(double Total, double Selection)
        {
            //
            // 排列函数（近似值）。
            //

            if (BackgroundWorker_Calc != null && BackgroundWorker_Calc.CancellationPending)
            {
                return new ACRslt();
            }

            //

            ACRslt AR = new ACRslt();
            AR.IsExactValue = true;

            SciN Fact_T = Stirling(Total);
            SciN Fact_TsubS = Stirling(Total - Selection);
            SciN SN_AR = SciNDivision(Fact_T, Fact_TsubS);

            if (double.IsNaN(SN_AR.Val))
            {
                AR.ValStr = "非数字";
            }
            else if (double.IsInfinity(SN_AR.Val))
            {
                AR.ValStr = "溢出";
            }
            else
            {
                if (SN_AR.Exp >= 15 || SN_AR.Exp <= -5)
                {
                    AR.ValStr = SN_AR.Val + " × 10";
                    AR.ExpStr = SN_AR.Exp.ToString();
                }
                else
                {
                    AR.ValStr = (SN_AR.Val * Math.Pow(10, SN_AR.Exp)).ToString();
                }
            }

            return AR;
        }

        private ACRslt Combination(double Total, double Selection)
        {
            //
            // 组合函数。
            //

            if (BackgroundWorker_Calc != null && BackgroundWorker_Calc.CancellationPending)
            {
                return new ACRslt();
            }

            //

            ACRslt CR = new ACRslt();
            CR.IsExactValue = true;

            SciN Fact_T = Factorial(Total);
            CycDone = 1;

            SciN Fact_S = Factorial(Selection);
            CycDone = 2;

            SciN Fact_TsubS = Factorial(Total - Selection);
            CycDone = 3;

            SciN SN_AR = SciNDivision(SciNDivision(Fact_T, Fact_S), Fact_TsubS);

            if (double.IsNaN(SN_AR.Val))
            {
                CR.ValStr = "非数字";
            }
            else if (double.IsInfinity(SN_AR.Val))
            {
                CR.ValStr = "溢出";
            }
            else
            {
                if (SN_AR.Exp >= 15 || SN_AR.Exp <= -5)
                {
                    CR.ValStr = SN_AR.Val + " × 10";
                    CR.ExpStr = SN_AR.Exp.ToString();
                }
                else
                {
                    CR.ValStr = (SN_AR.Val * Math.Pow(10, SN_AR.Exp)).ToString();
                }
            }

            return CR;
        }

        private ACRslt Combination_Approx(double Total, double Selection)
        {
            //
            // 组合函数（近似值）。
            //

            if (BackgroundWorker_Calc != null && BackgroundWorker_Calc.CancellationPending)
            {
                return new ACRslt();
            }

            //

            ACRslt CR = new ACRslt();
            CR.IsExactValue = true;

            SciN Fact_T = Stirling(Total);
            SciN Fact_S = Stirling(Selection);
            SciN Fact_TsubS = Stirling(Total - Selection);
            SciN SN_AR = SciNDivision(SciNDivision(Fact_T, Fact_S), Fact_TsubS);

            if (double.IsNaN(SN_AR.Val))
            {
                CR.ValStr = "非数字";
            }
            else if (double.IsInfinity(SN_AR.Val))
            {
                CR.ValStr = "溢出";
            }
            else
            {
                if (SN_AR.Exp >= 15 || SN_AR.Exp <= -5)
                {
                    CR.ValStr = SN_AR.Val + " × 10";
                    CR.ExpStr = SN_AR.Exp.ToString();
                }
                else
                {
                    CR.ValStr = (SN_AR.Val * Math.Pow(10, SN_AR.Exp)).ToString();
                }
            }

            return CR;
        }

        #endregion

        #region 后台计算

        private string Result_Equal, Result_Val, Result_Exp, Result_Time, Result_Time_BefStr; // 计算结果字符串。

        private void RefreshResult()
        {
            //
            // 刷新计算结果。
            //

            Label_Equal.Text = Result_Equal;
            Label_Val.Text = Result_Val;
            Label_Exp.Text = Result_Exp;
            Label_Time.Text = Result_Time;
        }

        // 后台计算异步线程。

        private BackgroundWorker BackgroundWorker_Calc = new BackgroundWorker(); // 后台计算异步线程。

        private DateTime LastWorkAsync = DateTime.Now; // 上次开始异步工作的时刻。
        private TimeSpan LastWorkAsyncToNow => DateTime.Now - LastWorkAsync; // 上次开始异步工作到现在的时间间隔。

        private void BackgroundWorker_Calc_DoWork(object sender, DoWorkEventArgs e)
        {
            //
            // 后台计算执行异步工作。
            //

            LastWorkAsync = DateTime.Now;

            //

            Calc_WorkAsync();
        }

        private DateTime LastReportProgress = DateTime.Now; // 上次报告异步工作进度的时刻。
        private TimeSpan LastReportProgressToNow => DateTime.Now - LastReportProgress; // 上次报告异步工作进度到现在的时间间隔。

        private void BackgroundWorker_Calc_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //
            // 后台计算异步工作进度改变。
            //

            LastReportProgress = DateTime.Now;

            //

            Calc_ReportProgress();
        }

        private void BackgroundWorker_Calc_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //
            // 后台计算异步工作完成。
            //

            if (!e.Cancelled)
            {
                Calc_WorkDone();
            }
        }

        // 计算步骤周期与时间。

        private const Int32 CycSteps = 3; // 最大计算步骤数。

        private double[] CycCount = new double[CycSteps]; // 所有计算步骤分别需要的循环或递归的周期数。

        private Int32 _CycDone = 0; // 已完成的计算步骤数。
        private Int32 CycDone
        {
            get
            {
                return _CycDone;
            }

            set
            {
                _CycDone = Math.Max(0, Math.Min(value, CycSteps));
            }
        }

        private double CycCount_Total // 所有计算步骤需要的循环或递归的总周期数。
        {
            get
            {
                double _CycCount_Total = 0;

                for (int i = 0; i <= CycSteps - 1; i++)
                {
                    double V = (double.IsNaN(CycCount[i]) || double.IsInfinity(CycCount[i]) || CycCount[i] <= 0 ? 0 : CycCount[i]);

                    _CycCount_Total += V;
                }

                return Math.Max(1, _CycCount_Total);
            }
        }
        private double CycCount_Done // 已完成的计算步骤数包含的循环或递归的周期数。
        {
            get
            {
                double _CycCount_Done = 0;

                for (int i = 0; i <= CycSteps - 1; i++)
                {
                    if (CycDone >= i + 1)
                    {
                        double V = (double.IsNaN(CycCount[i]) || double.IsInfinity(CycCount[i]) || CycCount[i] <= 0 ? 0 : CycCount[i]);

                        _CycCount_Done += V;
                    }
                    else
                    {
                        break;
                    }
                }

                return Math.Max(1, _CycCount_Done);
            }
        }

        private void CycReset()
        {
            //
            // 将 CycCount 的所有元素和 CycDone 重置为 0。
            //

            for (int i = 0; i <= CycSteps - 1; i++)
            {
                CycCount[i] = 0;
            }

            CycDone = 0;
        }

        private void ReportRemainingTime(double Cyc)
        {
            //
            // 向后台计算异步线程报告剩余时间。Cyc：当前计算步骤已完成的循环或递归的周期数。
            //

            if (BackgroundWorker_Calc != null && BackgroundWorker_Calc.WorkerReportsProgress && BackgroundWorker_Calc.IsBusy)
            {
                double _Cyc = CycCount_Done + Cyc;

                TimeSpan TS = TimeSpan.FromMilliseconds(LastWorkAsyncToNow.TotalMilliseconds / _Cyc * (CycCount_Total - _Cyc));

                Result_Time = Result_Time_BefStr + (TS.TotalMilliseconds >= 1000 ? "还需大约 " + GetTimeStringFromTimeSpan(TS) : "即将完成");

                BackgroundWorker_Calc.ReportProgress(0);
            }
        }

        // 后台计算异步工作控制。

        private void Calc_Start()
        {
            //
            // 后台计算开始。
            //

            CycReset();

            Result_Equal = Result_Val = Result_Exp = Result_Time = Result_Time_BefStr = string.Empty;

            //

            BackgroundWorker_Calc = new BackgroundWorker();

            BackgroundWorker_Calc.WorkerReportsProgress = true;
            BackgroundWorker_Calc.WorkerSupportsCancellation = true;
            BackgroundWorker_Calc.DoWork += BackgroundWorker_Calc_DoWork;
            BackgroundWorker_Calc.ProgressChanged += BackgroundWorker_Calc_ProgressChanged;
            BackgroundWorker_Calc.RunWorkerCompleted += BackgroundWorker_Calc_RunWorkerCompleted;

            if (!BackgroundWorker_Calc.IsBusy)
            {
                BackgroundWorker_Calc.RunWorkerAsync();
            }
        }

        private void Calc_Stop()
        {
            //
            // 后台计算停止。
            //

            if (BackgroundWorker_Calc != null)
            {
                BackgroundWorker_Calc.DoWork -= BackgroundWorker_Calc_DoWork;
                BackgroundWorker_Calc.ProgressChanged -= BackgroundWorker_Calc_ProgressChanged;
                BackgroundWorker_Calc.RunWorkerCompleted -= BackgroundWorker_Calc_RunWorkerCompleted;

                if (BackgroundWorker_Calc.IsBusy)
                {
                    BackgroundWorker_Calc.CancelAsync();
                }

                BackgroundWorker_Calc.Dispose();
            }
        }

        private void Calc_Restart()
        {
            //
            // 后台计算停止并重新开始。
            //

            Calc_Stop();
            Calc_Start();
        }

        private void Calc_WorkAsync()
        {
            //
            // 后台计算异步工作内容。
            //

            if (Validity_Total && Validity_Selection)
            {
                Func<double, double> GetCyc = (V) => (V == Math.Truncate(V) ? (V >= 0 ? (V < 1E15 ? V : 0) : 0) : Math.Abs(V) < 1E15 ? Math.Abs(V) : 0);

                CycCount[0] = GetCyc(Total_Input);
                CycCount[1] = GetCyc(NowArrangement ? Total_Input - Selection_Input : Selection_Input);
                CycCount[2] = GetCyc(NowArrangement ? 0 : Total_Input - Selection_Input);

                if (Total_Input >= 0 && Selection_Input >= 0 && Total_Input >= Selection_Input)
                {
                    ACRslt ACR_Stirling = (NowArrangement ? Arrangement_Approx(Total_Input, Selection_Input) : Combination_Approx(Total_Input, Selection_Input));

                    Result_Equal = "≈";
                    Result_Val = ACR_Stirling.ValStr;
                    Result_Exp = ACR_Stirling.ExpStr;
                    Result_Time = "正在计算准确值…";
                    Result_Time_BefStr = "正在计算准确值，";
                }
                else
                {
                    Result_Equal = "=";
                    Result_Val = "正在计算…";
                    Result_Time = "正在计算…";
                    Result_Time_BefStr = "正在计算，";
                }

                BackgroundWorker_Calc.ReportProgress(0);

                //

                Stopwatch Sw = new Stopwatch();
                Sw.Restart();

                ACRslt ACR = (NowArrangement ? Arrangement(Total_Input, Selection_Input) : Combination(Total_Input, Selection_Input));

                Sw.Stop();

                Result_Equal = "=";
                Result_Val = ACR.ValStr;
                Result_Exp = ACR.ExpStr;
                Result_Time = "用时 " + GetTimeStringFromTimeSpan(Sw.Elapsed);
                Result_Time_BefStr = string.Empty;
            }
            else
            {
                Result_Equal = "=";
                Result_Val = "无效输入";
                Result_Exp = string.Empty;
                Result_Time = Result_Time_BefStr = string.Empty;
            }
        }

        private void Calc_ReportProgress()
        {
            //
            // 后台计算报告异步工作进度。
            //

            RefreshResult();
        }

        private void Calc_WorkDone()
        {
            //
            // 后台计算异步工作完成。
            //

            RefreshResult();
        }

        #endregion

        #region 输入输出

        // 归零。

        private void ReturnToZero()
        {
            //
            // 归零。
            //

            Calc_Stop();

            //

            Total_Input = 0;
            Label_Total.TextChanged -= Label_Total_TextChanged;
            Label_Total.Text = "0";
            Label_Total.TextChanged += Label_Total_TextChanged;
            Validity_Total = true;

            Selection_Input = 0;
            Label_Selection.TextChanged -= Label_Selection_TextChanged;
            Label_Selection.Text = "0";
            Label_Selection.TextChanged += Label_Selection_TextChanged;
            Validity_Selection = true;

            //

            Label_Equal.Text = "=";
            Label_Val.Text = "1";
            Label_Exp.Text = string.Empty;
            Label_Time.Text = string.Empty;

            //

            Label_Total.Focus();
        }

        private void Label_ReturnToZero_Click(object sender, EventArgs e)
        {
            //
            // 单击 Label_ReturnToZero。
            //

            ReturnToZero();
        }

        // 输入合法性。

        private bool Validity_Total = false; // 输入的总数的合法性。
        private bool Validity_Selection = false; // 输入的选取数的合法性。

        // 输入区域容器。

        private void Panel_Input_MouseMove(object sender, MouseEventArgs e)
        {
            //
            // 鼠标经过 Panel_Input。
            //

            Point PTC = Panel_Input.PointToClient(Cursor.Position);

            if (PTC.X > Label_AC.Right)
            {
                if (PTC.Y >= Label_Total.Top)
                {
                    if (!Label_Total.Focused)
                    {
                        Label_Total.BackColor = PointedColor;
                    }

                    if (!Label_Selection.Focused)
                    {
                        Label_Selection.BackColor = UnfocusedColor;
                    }
                }
                else
                {
                    if (!Label_Selection.Focused)
                    {
                        Label_Selection.BackColor = PointedColor;
                    }

                    if (!Label_Total.Focused)
                    {
                        Label_Total.BackColor = UnfocusedColor;
                    }
                }
            }
        }

        private void Panel_Input_MouseLeave(object sender, EventArgs e)
        {
            //
            // 鼠标离开 Panel_Input。
            //

            if (!Label_Total.Focused)
            {
                Label_Total.BackColor = UnfocusedColor;
            }

            if (!Label_Selection.Focused)
            {
                Label_Selection.BackColor = UnfocusedColor;
            }
        }

        private void Panel_Input_MouseDown(object sender, MouseEventArgs e)
        {
            //
            // 鼠标按下 Panel_Input。
            //

            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                Point PTC = Panel_Input.PointToClient(Cursor.Position);

                if (PTC.X > Label_AC.Right)
                {
                    if (PTC.Y >= Label_Total.Top)
                    {
                        Label_Total.Focus();
                    }
                    else
                    {
                        Label_Selection.Focus();
                    }
                }
            }
        }

        private void Panel_Input_MouseUp(object sender, MouseEventArgs e)
        {
            //
            // 鼠标释放 Panel_Input。
            //

            if (e.Button == MouseButtons.Right)
            {
                Point PTC = Panel_Input.PointToClient(Cursor.Position);

                if (PTC.X > Label_AC.Right)
                {
                    if (PTC.Y >= Label_Total.Top)
                    {
                        ContextMenuStrip_Total.Show(Cursor.Position);
                    }
                    else
                    {
                        ContextMenuStrip_Selection.Show(Cursor.Position);
                    }
                }
            }
        }

        private void Panel_Input_LocationChanged(object sender, EventArgs e)
        {
            //
            // Panel_Input 位置改变。
            //

            Panel_Output.Left = Panel_Input.Right;
        }

        private void Panel_Input_SizeChanged(object sender, EventArgs e)
        {
            //
            // Panel_Input 大小改变。
            //

            Panel_Output.Left = Panel_Input.Right;
        }

        // 计算模式

        private bool _NowArrangement = true; // 当前计算模式是（true）否为排列。
        private bool NowArrangement
        {
            get
            {
                return _NowArrangement;
            }
            set
            {
                _NowArrangement = value;

                Label_AC.Text = (_NowArrangement ? "A" : "C");
            }
        }

        private void Label_AC_Click(object sender, EventArgs e)
        {
            //
            // 单击 Label_AC。
            //

            NowArrangement = !NowArrangement;

            //

            Calc_Restart();
        }

        // 输入值：底数。

        private void Label_Total_MouseMove(object sender, MouseEventArgs e)
        {
            //
            // 鼠标经过 Label_Total。
            //

            if (!Label_Total.Focused)
            {
                Label_Total.BackColor = PointedColor;
            }
        }

        private void Label_Total_MouseLeave(object sender, EventArgs e)
        {
            //
            // 鼠标离开 Label_Total。
            //

            if (!Label_Total.Focused)
            {
                Label_Total.BackColor = UnfocusedColor;
            }
        }

        private void Label_Total_MouseDown(object sender, MouseEventArgs e)
        {
            //
            // 鼠标按下 Label_Total。
            //

            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                Label_Total.Focus();
            }
        }

        private void Label_Total_GotFocus(object sender, EventArgs e)
        {
            //
            // Label_Total 接收焦点。
            //

            Label_Total.BackColor = FocusedColor;
        }

        private void Label_Total_LostFocus(object sender, EventArgs e)
        {
            //
            // Label_Total 失去焦点。
            //

            Label_Total.BackColor = UnfocusedColor;
        }

        private void Label_Total_KeyDown(object sender, KeyEventArgs e)
        {
            //
            // 在 Label_Total 按下键。
            //

            if (Label_Total.Visible)
            {
                switch (e.KeyCode)
                {
                    case Keys.D0:
                    case Keys.NumPad0:
                        Label_Total.Text += "0";
                        break;

                    case Keys.D1:
                    case Keys.NumPad1:
                        Label_Total.Text += "1";
                        break;

                    case Keys.D2:
                    case Keys.NumPad2:
                        Label_Total.Text += "2";
                        break;

                    case Keys.D3:
                    case Keys.NumPad3:
                        Label_Total.Text += "3";
                        break;

                    case Keys.D4:
                    case Keys.NumPad4:
                        Label_Total.Text += "4";
                        break;

                    case Keys.D5:
                    case Keys.NumPad5:
                        Label_Total.Text += "5";
                        break;

                    case Keys.D6:
                    case Keys.NumPad6:
                        Label_Total.Text += "6";
                        break;

                    case Keys.D7:
                    case Keys.NumPad7:
                        Label_Total.Text += "7";
                        break;

                    case Keys.D8:
                    case Keys.NumPad8:
                        Label_Total.Text += "8";
                        break;

                    case Keys.D9:
                    case Keys.NumPad9:
                        Label_Total.Text += "9";
                        break;

                    case Keys.OemMinus:
                    case Keys.Subtract:
                        Label_Total.Text += "-";
                        break;

                    case Keys.OemPeriod:
                    case Keys.Decimal:
                        Label_Total.Text += ".";
                        break;

                    case Keys.Back:
                        Label_Total.Text = Label_Total.Text.Substring(0, Math.Max(0, Label_Total.Text.Length - 1));
                        break;

                    case Keys.Delete:
                        Label_Total.Text = "0";
                        break;

                    case Keys.Escape:
                        ReturnToZero();
                        break;

                    case Keys.Right:
                    case Keys.Up:
                    case Keys.PageDown:
                    case Keys.Space:
                        Label_Selection.Focus();
                        break;
                }
            }
        }

        private void Label_Total_TextChanged(object sender, EventArgs e)
        {
            //
            // Label_Total 文本改变。
            //

            string Str = Label_Total.Text;

            REJUDGE:

            Str = new Regex(@"[^\d\.\-]").Replace(Str, string.Empty);

            Int32 MCount = Regex.Matches(Str, @"-").Count; // "-" 出现在文本的次数。
            Int32 DIndex = Str.IndexOf("."); // "." 第一次出现在文本的位置。

            if (MCount % 2 == 0) // "-" 出现偶数次。
            {
                if (DIndex == -1) // "." 未出现。
                {
                    string Text = new Regex(@"[^\d]").Replace(Str, string.Empty).Substring(0, Math.Min(15, new Regex(@"[^\d]").Replace(Str, string.Empty).Length));

                    if (Text.Length > 0)
                    {
                        Str = Convert.ToDouble(Text).ToString();
                    }
                    else
                    {
                        Str = "0";
                    }

                    Validity_Total = true;
                } // "." 未出现。
                else // "." 出现。
                {
                    string BeforeD = new Regex(@"[^\d]").Replace(Str.Substring(0, DIndex), string.Empty);
                    string AfterD = new Regex(@"[^\d]").Replace(Str.Substring(DIndex + 1), string.Empty);

                    string Part1 = BeforeD.Substring(0, Math.Min(15, BeforeD.Length));
                    string Part2 = AfterD.Substring(0, Math.Min(15 - Part1.Length, AfterD.Length));

                    if (Part1.Length > 0)
                    {
                        if (Part2.Length > 0)
                        {
                            Str = Convert.ToDouble(Part1) + "." + Part2;

                            Validity_Total = true;
                        }
                        else if (Part1.Length < 15)
                        {
                            Str = Convert.ToDouble(Part1) + ".";

                            Validity_Total = false;
                        }
                        else
                        {
                            Str = Convert.ToDouble(Part1).ToString();

                            goto REJUDGE;
                        }
                    }
                    else
                    {
                        Str = "0";

                        goto REJUDGE;
                    }
                } // "." 出现。
            } // "-" 出现偶数次。
            else // "-" 出现奇数次。
            {
                if (DIndex == -1) // "." 未出现。
                {
                    string Text = new Regex(@"[^\d]").Replace(Str, string.Empty).Substring(0, Math.Min(15, new Regex(@"[^\d]").Replace(Str, string.Empty).Length));

                    if (Text.Length > 0)
                    {
                        Str = "-" + Convert.ToDouble(Text);

                        Validity_Total = true;
                    }
                    else
                    {
                        Str = "-";

                        Validity_Total = false;
                    }
                } // "." 未出现。
                else // "." 出现。
                {
                    string BeforeD = new Regex(@"[^\d]").Replace(Str.Substring(0, DIndex), string.Empty);
                    string AfterD = new Regex(@"[^\d]").Replace(Str.Substring(DIndex + 1), string.Empty);

                    string Part1 = BeforeD.Substring(0, Math.Min(15, BeforeD.Length));
                    string Part2 = AfterD.Substring(0, Math.Min(15 - Part1.Length, AfterD.Length));

                    if (Part1.Length > 0)
                    {
                        if (Part2.Length > 0)
                        {
                            Str = "-" + Convert.ToDouble(Part1) + "." + Part2;

                            Validity_Total = true;
                        }
                        else if (Part1.Length < 15)
                        {
                            Str = "-" + Convert.ToDouble(Part1) + ".";

                            Validity_Total = false;
                        }
                        else
                        {
                            Str = "-" + Convert.ToDouble(Part1);

                            goto REJUDGE;
                        }
                    }
                    else
                    {
                        Str = "-";

                        goto REJUDGE;
                    }
                } // "." 出现。
            } // "-" 出现奇数次。

            Label_Total.TextChanged -= Label_Total_TextChanged;
            Label_Total.Text = Str;
            Label_Total.TextChanged += Label_Total_TextChanged;

            //

            if (Validity_Total)
            {
                Total_Input = Convert.ToDouble(Label_Total.Text);
            }

            //

            Calc_Restart();
        }

        private void Label_Total_LocationChanged(object sender, EventArgs e)
        {
            //
            // Label_Total 位置改变。
            //

            Panel_Input.Width = Math.Max(200, Math.Max(Label_Total.Right, Label_Selection.Right));
        }

        private void Label_Total_SizeChanged(object sender, EventArgs e)
        {
            //
            // Label_Total 大小改变。
            //

            Panel_Input.Width = Math.Max(200, Math.Max(Label_Total.Right, Label_Selection.Right));
        }

        // 输入值：指数。

        private void Label_Selection_MouseMove(object sender, MouseEventArgs e)
        {
            //
            // 鼠标经过 Label_Selection。
            //

            if (!Label_Selection.Focused)
            {
                Label_Selection.BackColor = PointedColor;
            }
        }

        private void Label_Selection_MouseLeave(object sender, EventArgs e)
        {
            //
            // 鼠标离开 Label_Selection。
            //

            if (!Label_Selection.Focused)
            {
                Label_Selection.BackColor = UnfocusedColor;
            }
        }

        private void Label_Selection_MouseDown(object sender, MouseEventArgs e)
        {
            //
            // 鼠标按下 Label_Selection。
            //

            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                Label_Selection.Focus();
            }
        }

        private void Label_Selection_GotFocus(object sender, EventArgs e)
        {
            //
            // Label_Selection 接收焦点。
            //

            Label_Selection.BackColor = FocusedColor;
        }

        private void Label_Selection_LostFocus(object sender, EventArgs e)
        {
            //
            // Label_Selection 失去焦点。
            //

            Label_Selection.BackColor = UnfocusedColor;
        }

        private void Label_Selection_KeyDown(object sender, KeyEventArgs e)
        {
            //
            // 在 Label_Selection 按下键。
            //

            if (Label_Selection.Visible)
            {
                switch (e.KeyCode)
                {
                    case Keys.D0:
                    case Keys.NumPad0:
                        Label_Selection.Text += "0";
                        break;

                    case Keys.D1:
                    case Keys.NumPad1:
                        Label_Selection.Text += "1";
                        break;

                    case Keys.D2:
                    case Keys.NumPad2:
                        Label_Selection.Text += "2";
                        break;

                    case Keys.D3:
                    case Keys.NumPad3:
                        Label_Selection.Text += "3";
                        break;

                    case Keys.D4:
                    case Keys.NumPad4:
                        Label_Selection.Text += "4";
                        break;

                    case Keys.D5:
                    case Keys.NumPad5:
                        Label_Selection.Text += "5";
                        break;

                    case Keys.D6:
                    case Keys.NumPad6:
                        Label_Selection.Text += "6";
                        break;

                    case Keys.D7:
                    case Keys.NumPad7:
                        Label_Selection.Text += "7";
                        break;

                    case Keys.D8:
                    case Keys.NumPad8:
                        Label_Selection.Text += "8";
                        break;

                    case Keys.D9:
                    case Keys.NumPad9:
                        Label_Selection.Text += "9";
                        break;

                    case Keys.OemMinus:
                    case Keys.Subtract:
                        Label_Selection.Text += "-";
                        break;

                    case Keys.OemPeriod:
                    case Keys.Decimal:
                        Label_Selection.Text += ".";
                        break;

                    case Keys.Back:
                        Label_Selection.Text = Label_Selection.Text.Substring(0, Math.Max(0, Label_Selection.Text.Length - 1));
                        break;

                    case Keys.Delete:
                        Label_Selection.Text = "0";
                        break;

                    case Keys.Escape:
                        ReturnToZero();
                        break;

                    case Keys.Left:
                    case Keys.Down:
                    case Keys.PageUp:
                    case Keys.Space:
                        Label_Total.Focus();
                        break;
                }
            }
        }

        private void Label_Selection_TextChanged(object sender, EventArgs e)
        {
            //
            // Label_Selection 文本改变。
            //

            string Str = Label_Selection.Text;

            REJUDGE:

            Str = new Regex(@"[^\d\.\-]").Replace(Str, string.Empty);

            Int32 MCount = Regex.Matches(Str, @"-").Count; // "-" 出现在文本的次数。
            Int32 DIndex = Str.IndexOf("."); // "." 第一次出现在文本的位置。

            if (MCount % 2 == 0) // "-" 出现偶数次。
            {
                if (DIndex == -1) // "." 未出现。
                {
                    string Text = new Regex(@"[^\d]").Replace(Str, string.Empty).Substring(0, Math.Min(15, new Regex(@"[^\d]").Replace(Str, string.Empty).Length));

                    if (Text.Length > 0)
                    {
                        Str = Convert.ToDouble(Text).ToString();
                    }
                    else
                    {
                        Str = "0";
                    }

                    Validity_Selection = true;
                } // "." 未出现。
                else // "." 出现。
                {
                    string BeforeD = new Regex(@"[^\d]").Replace(Str.Substring(0, DIndex), string.Empty);
                    string AfterD = new Regex(@"[^\d]").Replace(Str.Substring(DIndex + 1), string.Empty);

                    string Part1 = BeforeD.Substring(0, Math.Min(15, BeforeD.Length));
                    string Part2 = AfterD.Substring(0, Math.Min(15 - Part1.Length, AfterD.Length));

                    if (Part1.Length > 0)
                    {
                        if (Part2.Length > 0)
                        {
                            Str = Convert.ToDouble(Part1) + "." + Part2;

                            Validity_Selection = true;
                        }
                        else if (Part1.Length < 15)
                        {
                            Str = Convert.ToDouble(Part1) + ".";

                            Validity_Selection = false;
                        }
                        else
                        {
                            Str = Convert.ToDouble(Part1).ToString();

                            goto REJUDGE;
                        }
                    }
                    else
                    {
                        Str = "0";

                        goto REJUDGE;
                    }
                } // "." 出现。
            } // "-" 出现偶数次。
            else // "-" 出现奇数次。
            {
                if (DIndex == -1) // "." 未出现。
                {
                    string Text = new Regex(@"[^\d]").Replace(Str, string.Empty).Substring(0, Math.Min(15, new Regex(@"[^\d]").Replace(Str, string.Empty).Length));

                    if (Text.Length > 0)
                    {
                        Str = "-" + Convert.ToDouble(Text);

                        Validity_Selection = true;
                    }
                    else
                    {
                        Str = "-";

                        Validity_Selection = false;
                    }
                } // "." 未出现。
                else // "." 出现。
                {
                    string BeforeD = new Regex(@"[^\d]").Replace(Str.Substring(0, DIndex), string.Empty);
                    string AfterD = new Regex(@"[^\d]").Replace(Str.Substring(DIndex + 1), string.Empty);

                    string Part1 = BeforeD.Substring(0, Math.Min(15, BeforeD.Length));
                    string Part2 = AfterD.Substring(0, Math.Min(15 - Part1.Length, AfterD.Length));

                    if (Part1.Length > 0)
                    {
                        if (Part2.Length > 0)
                        {
                            Str = "-" + Convert.ToDouble(Part1) + "." + Part2;

                            Validity_Selection = true;
                        }
                        else if (Part1.Length < 15)
                        {
                            Str = "-" + Convert.ToDouble(Part1) + ".";

                            Validity_Selection = false;
                        }
                        else
                        {
                            Str = "-" + Convert.ToDouble(Part1);

                            goto REJUDGE;
                        }
                    }
                    else
                    {
                        Str = "-";

                        goto REJUDGE;
                    }
                } // "." 出现。
            } // "-" 出现奇数次。

            Label_Selection.TextChanged -= Label_Selection_TextChanged;
            Label_Selection.Text = Str;
            Label_Selection.TextChanged += Label_Selection_TextChanged;

            //

            if (Validity_Selection)
            {
                Selection_Input = Convert.ToDouble(Label_Selection.Text);
            }

            //

            Calc_Restart();
        }

        private void Label_Selection_LocationChanged(object sender, EventArgs e)
        {
            //
            // Label_Selection 位置改变。
            //

            Panel_Input.Width = Math.Max(200, Math.Max(Label_Total.Right, Label_Selection.Right));
        }

        private void Label_Selection_SizeChanged(object sender, EventArgs e)
        {
            //
            // Label_Selection 大小改变。
            //

            Panel_Input.Width = Math.Max(200, Math.Max(Label_Total.Right, Label_Selection.Right));
        }

        // 输出区域容器。

        private void ResizeForm()
        {
            //
            // 重置窗体大小。
            //

            Me.Width = Panel_Output.Right + Panel_Input.Left;
            Me.X = Math.Max(0, Math.Min(Screen.PrimaryScreen.WorkingArea.X + Screen.PrimaryScreen.WorkingArea.Width - Me.Width, Me.X));
        }

        private void Panel_Output_LocationChanged(object sender, EventArgs e)
        {
            //
            // Panel_Output 位置改变。
            //

            Label_ReturnToZero.Left = Panel_Output.Right - Label_ReturnToZero.Width;

            //

            ResizeForm();
        }

        private void Panel_Output_SizeChanged(object sender, EventArgs e)
        {
            //
            // Panel_Output 大小改变。
            //

            Label_ReturnToZero.Left = Panel_Output.Right - Label_ReturnToZero.Width;

            //

            ResizeForm();
        }

        // 输出值标签。

        private void Label_Val_LocationChanged(object sender, EventArgs e)
        {
            //
            // Label_Val 位置改变。
            //

            Label_Exp.Left = Label_Val.Right;
        }

        private void Label_Val_SizeChanged(object sender, EventArgs e)
        {
            //
            // Label_Val 大小改变。
            //

            Label_Exp.Left = Label_Val.Right;
        }

        private void Label_Exp_LocationChanged(object sender, EventArgs e)
        {
            //
            // Label_Exp 位置改变。
            //

            Panel_Output.Width = Math.Max(200, Label_Exp.Right);
        }

        private void Label_Exp_SizeChanged(object sender, EventArgs e)
        {
            //
            // Label_Exp 大小改变。
            //

            Panel_Output.Width = Math.Max(200, Label_Exp.Right);
        }

        #endregion

        #region 菜单项

        // 输入。

        private void ToolStripMenuItem_Total_Copy_Click(object sender, EventArgs e)
        {
            //
            // 单击 ToolStripMenuItem_Total_Copy。
            //

            if (Label_Total.Text != string.Empty)
            {
                Clipboard.SetDataObject(Label_Total.Text);
            }
        }

        private void ToolStripMenuItem_Total_Paste_Click(object sender, EventArgs e)
        {
            //
            // 单击 ToolStripMenuItem_Total_Paste。
            //

            IDataObject Data = Clipboard.GetDataObject();

            if (Data.GetDataPresent(DataFormats.Text))
            {
                Label_Total.Text = (string)Data.GetData(DataFormats.Text);
            }
        }

        private void ToolStripMenuItem_Selection_Copy_Click(object sender, EventArgs e)
        {
            //
            // 单击 ToolStripMenuItem_Selection。
            //

            if (Label_Selection.Text != string.Empty)
            {
                Clipboard.SetDataObject(Label_Selection.Text);
            }
        }

        private void ToolStripMenuItem_Selection_Paste_Click(object sender, EventArgs e)
        {
            //
            // 单击 ToolStripMenuItem_Selection_Paste。
            //

            IDataObject Data = Clipboard.GetDataObject();

            if (Data.GetDataPresent(DataFormats.Text))
            {
                Label_Selection.Text = (string)Data.GetData(DataFormats.Text);
            }
        }

        // 输出。

        private void ToolStripMenuItem_Output_Copy_Click(object sender, EventArgs e)
        {
            //
            // 单击 ToolStripMenuItem_Output_Copy。
            //

            if (Label_Val.Text != string.Empty)
            {
                if (Label_Exp.Text == string.Empty)
                {
                    Clipboard.SetDataObject(Label_Val.Text);
                }
                else
                {
                    Clipboard.SetDataObject(Label_Val.Text + " ^ " + Label_Exp.Text);
                }
            }
        }

        #endregion

        #region 公用函数与方法

        private string GetTimeStringFromTimeSpan(TimeSpan TS)
        {
            //
            // 将以毫秒数表示的时间间隔转换为字符串。
            //

            //
            // 获取时间间隔的字符串。TS：时间间隔。
            //

            try
            {
                return (TS.TotalHours >= 1 ? Math.Floor(TS.TotalHours) + " 小时 " + TS.Minutes + " 分 " + TS.Seconds + " 秒" : (TS.TotalMinutes >= 1 ? TS.Minutes + " 分 " + TS.Seconds + " 秒" : (TS.TotalSeconds >= 1 ? TS.Seconds + "." + TS.Milliseconds.ToString("D3").Substring(0, TS.Seconds >= 10 ? 1 : 2) + " 秒" : (TS.TotalMilliseconds >= 1 ? Math.Truncate(TS.TotalMilliseconds) + (TS.TotalMilliseconds < 100 ? "." + ((Int32)((TS.TotalMilliseconds - Math.Truncate(TS.TotalMilliseconds)) * 1000)).ToString("D3").Substring(0, TS.TotalMilliseconds >= 10 ? 1 : 2) : string.Empty) + " 毫秒" : (TS.TotalMilliseconds * 1000 >= 0.1 ? Math.Truncate(TS.TotalMilliseconds * 1000) + (TS.TotalMilliseconds * 1000 < 100 ? "." + ((Int32)((TS.TotalMilliseconds * 1000 - Math.Truncate(TS.TotalMilliseconds * 1000)) * 1000)).ToString("D3").Substring(0, 1) : string.Empty) + " 微秒" : "小于 0.1 微秒")))));
            }
            catch
            {
                return string.Empty;
            }
        }

        #endregion

    }
}