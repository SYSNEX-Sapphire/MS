using CommunityToolkit.Mvvm.ComponentModel;
using SapphireXR_App.Bases;
using SapphireXR_App.Common;
using SapphireXR_App.Models;
using System.Collections.Specialized;
using System.ComponentModel;

namespace SapphireXR_App.ViewModels
{
    public partial class RecipeEditViewModel: ViewModelBase
    {
        public partial class RecipeInformationViewModel : ObservableObject, IObserver<IList<Recipe>>, IDisposable
        {
            public RecipeInformationViewModel(RecipeObservableCollection recipeList)
            {
                recipes = recipeList;
                recipes.CollectionChanged += recipeCollectionChanged;
                unsubscriber = ObservableManager<IList<Recipe>>.Subscribe("RecipeEdit.TabDataGrid.RecipeAdded", this);
                foreach (Recipe recipe in recipes)
                {
                    recipe.PropertyChanged += recipePropertyChanged;
                }
                refreshTotal();
            }

            private void recipeCollectionChanged(object? sender, NotifyCollectionChangedEventArgs args)
            {
                refreshTotal();
            }

            private void recipePropertyChanged(object? sender, PropertyChangedEventArgs args)
            {
                switch (args.PropertyName)
                {
                    case nameof(Recipe.RTime):
                        if (sender == currentStep || sender == prevStep)
                        {
                            refreshRampingRateTemp();
                            refreshRampingRatePress();
                        }
                        refreshTotal();
                        break;

                    case nameof(Recipe.HTime):
                        refreshTotal();
                        break;

                    case nameof(Recipe.STemp):
                        if (sender == currentStep || sender == prevStep)
                        {
                            refreshRampingRateTemp();
                        }
                        break;

                    case nameof(Recipe.RPress):
                        if (sender == currentStep || sender == prevStep)
                        {
                            refreshRampingRatePress();
                        }
                        break;

                    case nameof(Recipe.M01):
                    case nameof(Recipe.M02):
                    case nameof(Recipe.M03):
                    case nameof(Recipe.M04):
                    case nameof(Recipe.M05):
                    case nameof(Recipe.M06):
                    case nameof(Recipe.M07):
                    case nameof(Recipe.M08):
                    case nameof(Recipe.M09):
                    case nameof(Recipe.M10):
                    case nameof(Recipe.V14):
                    case nameof(Recipe.V15):
                    case nameof(Recipe.V16):
                    case nameof(Recipe.V17):
                    case nameof(Recipe.V18):
                    case nameof(Recipe.V19):
                        refreshTotalFlowRate();
                        break;
                }
            }

            private void refreshTotal()
            {
                if (0 < recipes.Count)
                {
                    int totalTime = 0;
                    foreach (Recipe recipe in recipes)
                    {
                        totalTime += (recipe.RTime + recipe.HTime);
                    }
                    TotalRecipeTime = totalTime;
                    TotalStepNumber = recipes.Count;
                }
                else
                {
                    TotalRecipeTime = null;
                    TotalStepNumber = null;
                }
            }

            private void refreshRampingRateTemp()
            {
                if (currentStep == null)
                {
                    return;
                }

                try
                {
                    float sTempDiff = currentStep.STemp;
                    if (prevStep != null)
                    {
                        sTempDiff = Math.Abs(sTempDiff - prevStep.STemp);
                    }
                    RampingRateTemp = sTempDiff / currentStep.RTime;
                }
                catch
                {
                    RampingRateTemp = null;
                }
            }

            private void refreshRampingRatePress()
            {
                if (currentStep == null)
                {
                    return;
                }

                try
                {
                    float rPressDiff = currentStep.RPress;
                    if (prevStep != null)
                    {
                        rPressDiff = Math.Abs(rPressDiff - prevStep.RPress);
                    }
                    RampingRatePress = rPressDiff / currentStep.RTime;
                }
                catch
                {
                    RampingRatePress = null;
                }
            }

            private void refreshTotalFlowRate()
            {
                if(currentStep == null)
                {
                    return;
                }

                float totalFlowRate = 0;
                totalFlowRate += currentStep.M01;
                totalFlowRate += currentStep.M02;
                if(currentStep.V17 == true)
                {
                    totalFlowRate += currentStep.M03;
                }
                if (currentStep.V18 == true)
                {
                    totalFlowRate += currentStep.M04;
                }
                if (currentStep.V14 == true)
                {
                    totalFlowRate += currentStep.M05;
                }
                if (currentStep.V15 == true)
                {
                    totalFlowRate += currentStep.M06;
                }
                if (currentStep.V16 == true)
                {
                    totalFlowRate += currentStep.M07;
                }
                if (currentStep.V19 == true)
                {
                    totalFlowRate += currentStep.M08;
                }
                totalFlowRate += currentStep.M09;
                totalFlowRate += currentStep.M10;


                TotalFlowRate = (int)totalFlowRate;
            }

            public void setCurrentRecipe(Recipe? recipe)
            {
                if (recipe != null)
                {
                    currentStep = recipe;
                    int prevStepIndex = recipe.No - 2;
                    if (0 <= prevStepIndex && prevStepIndex < recipes.Count)
                    {
                        prevStep = recipes[prevStepIndex];
                    }
                    else
                    {
                        prevStep = null;
                    }

                    refreshRampingRatePress();
                    refreshRampingRateTemp();
                    refreshTotalFlowRate();
                }
                else
                {
                    currentStep = null;
                    prevStep = null;

                    RampingRatePress = null;
                    RampingRateTemp = null;
                    TotalFlowRate = null;
                }
            }

            void IObserver<IList<Recipe>>.OnCompleted()
            {
                throw new NotImplementedException();
            }

            void IObserver<IList<Recipe>>.OnError(Exception error)
            {
                throw new NotImplementedException();
            }

            void IObserver<IList<Recipe>>.OnNext(IList<Recipe> newlyAdded)
            {
                foreach (Recipe recipe in newlyAdded)
                {
                    recipe.PropertyChanged += recipePropertyChanged;
                }
            }

            protected virtual void Dispose(bool disposing)
            {
                if (!disposedValue)
                {
                    if (disposing)
                    {
                        unsubscriber.Dispose();
                    }

                    // TODO: 비관리형 리소스(비관리형 개체)를 해제하고 종료자를 재정의합니다.
                    // TODO: 큰 필드를 null로 설정합니다.
                    disposedValue = true;
                }
            }

            void IDisposable.Dispose()
            {
                // 이 코드를 변경하지 마세요. 'Dispose(bool disposing)' 메서드에 정리 코드를 입력합니다.
                Dispose(disposing: true);
                GC.SuppressFinalize(this);
            }

            public void dispose()
            {
                Dispose(disposing: true);
            }

            [ObservableProperty]
            private int? _totalRecipeTime = null;
            [ObservableProperty]
            private int? _totalStepNumber = null;
            [ObservableProperty]
            private float? _rampingRateTemp = null;
            [ObservableProperty]
            private float? _rampingRatePress = null;
            [ObservableProperty]
            private float? _totalFlowRate = null;

            private Recipe? prevStep = null;
            private Recipe? currentStep = null;

            private RecipeObservableCollection recipes;
            private IDisposable unsubscriber;
            private bool disposedValue = false;
        }
    }
}
