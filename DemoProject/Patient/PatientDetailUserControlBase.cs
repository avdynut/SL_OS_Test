#region Usings

using System;
using System.Collections.Generic;
using System.ComponentModel;
//using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
////using GalaSoft.MvvmLight.Command;
//using OpenRiaServices.DomainServices.Client;
//using Virtuoso.Core.Cache;
//using Virtuoso.Core.Cache.Extensions;
//using Virtuoso.Core.Controls;
//using Virtuoso.Core.Framework;
//using Virtuoso.Core.Services;
//using Virtuoso.Server.Data;

#endregion

namespace Virtuoso.Maintenance.Controls
{
    public class PatientDetailUserControlBase : UserControl //DetailUserControlBase<PatientDetailUserControl, Patient>
    {
//        public PatientDetailUserControlBase()
//        {
//            ImportPhotoCommand = new RelayCommand(() =>
//            {
//                OnImportExecute();
//                RaiseCanExecuteChanged();
//            }, () => IsOnline);

//            SendInviteToPatientPortal = new RelayCommand(() => { _SendInviteToPatientPortal(); });

//            AddTranslatorCommand = new RelayCommand(() =>
//            {
//                SelectedItem.PatientTranslator.Add(new PatientTranslator());
//                OK_Command.RaiseCanExecuteChanged();
//            });

//            RemoveTranslatorCommand = new RelayCommand<PatientTranslator>(pt =>
//            {
//                pt.ValidationErrors.Clear();
//                SelectedItem.PatientTranslator.Remove(pt);
//                Model.Remove(pt);
//                if (SelectedItem.PatientTranslator.Any() == false)
//                {
//                    SelectedItem.Translator = false;
//                }

//                OK_Command.RaiseCanExecuteChanged();
//            });

//            AddPatientGenderExpressionCommand = new RelayCommand(() =>
//            {
//                _HasChangesOverride = true;
//                SelectedItem.ValidationErrors.Clear();

//                SelectedItem.AddNewGenderExpression();

//                RaisePropertyChanged("PatientGenderExpressionCVS");
//                PatientGenderExpressionCVS.Refresh();
//                OK_Command.RaiseCanExecuteChanged();
//            });

//            RemovePatientGenderExpressionCommand = new RelayCommand<PatientGenderExpression>(pt =>
//            {
//                _HasChangesOverride = true;
//                SelectedItem.ValidationErrors.Clear();
//                pt.ValidationErrors.Clear();
//                pt.InactiveDate = DateTime.UtcNow;
//                pt.EndEditting();

//                if (pt.IsNew)
//                {
//                    SelectedItem.RemoveGenderExpression(pt);
//                    Model.Remove(pt);
//                }

//                RaisePropertyChanged("PatientGenderExpressionCVS");
//                PatientGenderExpressionCVS.Refresh();
//                OK_Command.RaiseCanExecuteChanged();
//            });
//            ItemSelected += PatientDetailUserControlBase_ItemSelected;
//        }

//        private CollectionViewSource _PatientGenderExpressionCVS = new CollectionViewSource();
//        public ICollectionView PatientGenderExpressionCVS => _PatientGenderExpressionCVS.View;

//        public string SendInviteButtonText
//        {
//            get
//            {
//                if (SelectedItem != null)
//                {
//                    if (SelectedItem.ShowModuleInviteDate)
//                    {
//                        return "Resend " + SelectedItem.ModuleAccessName + " Invite";
//                    }

//                    return "Send " + SelectedItem.ModuleAccessName + " Invite";
//                }

//                return "Send Invite";
//            }
//        }

//        public void PatientGenderExpressionCVSSetup()
//        {
//            _PatientGenderExpressionCVS = new CollectionViewSource();

//            if (SelectedItem == null)
//            {
//                return;
//            }

//            _PatientGenderExpressionCVS.SortDescriptions.Add(new SortDescription("EffectiveFromDate",
//                ListSortDirection.Ascending));
//            Patient p = SelectedItem;
//            _PatientGenderExpressionCVS.Source = p.PatientGenderExpression;
//            PatientGenderExpressionCVS.Refresh();
//            RaisePropertyChanged("PatientGenderExpression");
//            RaisePropertyChanged("PatientGenderExpressionCVS");

//            RaisePropertyChanged("CanEditDeathDate");
//            RaisePropertyChanged("SendInviteButtonText");
//        }

//        public bool CanEditDeathDate
//        {
//            get
//            {
//                if (!IsEdit)
//                {
//                    return false;
//                }

//                if (SelectedItem == null)
//                {
//                    return false;
//                }

//                if (SelectedItem.Admission == null)
//                {
//                    return true;
//                }

//                // if an admission record has a value, it must be edited in Admission/Referral (Time is only keyed in an Encounter)
//                if (SelectedItem.Admission.Any(a => a.DeathTime.HasValue))
//                {
//                    return false;
//                }

//                if (SelectedItem.Admission.Any(a => a.AdmissionStatusCode != "D" && a.AdmissionStatusCode != "N"))
//                {
//                    return false;
//                }

//                return true;
//            }
//        }

//        public override void Cleanup()
//        {
//            ItemSelected -= PatientDetailUserControlBase_ItemSelected;

//            _PatientGenderExpressionCVS.Source = null;

//            ImportPhotoCommand = null;
//            SendInviteToPatientPortal = null;
//            AddTranslatorCommand = null;
//            RemoveTranslatorCommand = null;
//            AddPatientGenderExpressionCommand = null;
//            RemovePatientGenderExpressionCommand = null;
            
//            Model = null;

//            base.Cleanup();
//        }

//        void PatientDetailUserControlBase_ItemSelected(object sender, EventArgs e)
//        {
//            PatientGenderExpressionCVSSetup();

//            ProcessPhotos();
//        }

//        public void _SendInviteToPatientPortal()
//        {
//            if (SelectedItem != null)
//            {
//                string email = SelectedItem.EmailAddress;
//                if (email == null || email == string.Empty ||
//                    !Core.Validations.EmailAddressChecker.IsValidEmailAddress(email))
//                {
//                    MessageBox.Show("The email address does not appear to pass basic email validation.",
//                        "Invalid Email Address", MessageBoxButton.OK);
//                }
//                else
//                {
//                    var date = DateTime.UtcNow;
//                    // Refresh copy of invite data...
//                    Guid CreatedBy = UserCache.Current.GetCurrentUserProfile().UserId;
//                    Model.GeneratePatientPortalInvite(SelectedItem.PatientKey, CreatedBy);
//                }
//            }
//        }

//        public void ProcessPhotos()
//        {
//            if (SelectedItem != null)
//            {
//                FilteredPhotos = new PagedCollectionView(SelectedItem.PatientPhoto);
//                FilteredPhotos.Filter = item =>
//                {
//                    var photo = item as PatientPhoto;
//                    return (photo.HistoryKey == null);
//                };
//                RaisePropertyChanged("FilteredPhotos");
//            }
//        }

//        public ICollectionView FilteredPhotos { get; set; }

//        public RelayCommand ImportPhotoCommand { get; protected set; }

//        public RelayCommand SendInviteToPatientPortal { get; protected set; }
//        public RelayCommand AddTranslatorCommand { get; protected set; }
//        public RelayCommand<PatientTranslator> RemoveTranslatorCommand { get; protected set; }


//        public RelayCommand AddPatientGenderExpressionCommand { get; protected set; }
//        public RelayCommand<PatientGenderExpression> RemovePatientGenderExpressionCommand { get; protected set; }

//        public IPatientService Model
//        {
//            get { return (IPatientService)GetValue(ModelProperty); }
//            set { SetValue(ModelProperty, value); }
//        }

//#if OPENSILVER
//        public async void OnImportExecute()
//        {
//            var ofd = new FileDialogs.OpenFileDialog() { Filter = "Image files (*.jpg;*.png)|*.jpg;*.png|JPEG file|*.jpg|PNG file|*.png", ResultKind = FileDialogs.ResultKind.DataURL };

//            if(await ofd.ShowDialog() == true)
//            {
//                var firstFile = ofd.File;
//                if(firstFile != null)
//                {
//                    var photo = firstFile.Buffer;
//                    var curr_patient_photo = SelectedItem.PatientPhoto.FirstOrDefault(p => p.HistoryKey == null);
//                    if(curr_patient_photo != null)
//                    {
//                        curr_patient_photo.BeginEditting();
//                        curr_patient_photo.Photo = photo;
//                    }
//                    else
//                    {
//                        var new_photo = new PatientPhoto
//                        {
//                            TenantID = SelectedItem.TenantID,
//                            Photo = photo,
//                            UpdatedBy = SelectedItem.UpdatedBy,
//                            UpdatedDate = SelectedItem.UpdatedDate
//                        };
//                        new_photo.BeginEditting();
//                        SelectedItem.PatientPhoto.Add(new_photo);
//                    }
//                }
//            }
//        }
//#else
//        public void OnImportExecute()
//        {
//            OpenFileDialog ofd = new OpenFileDialog
//            {
//                Multiselect = false,

//                //Using GIF bytes will GPF the application when used as 'source' to image controls.
//                //INFO: Only allow JPG and PNG - DO NOT allow GIF, Silverlight does not support GIF.
//                Filter = "Image files (*.jpg;*.png)|*.jpg;*.png|JPEG file|*.jpg|PNG file|*.png"
//            };

//            if ((bool)ofd.ShowDialog())
//            {
//                FileInfo fi = ofd.File;
//                if (fi != null)
//                {
//                    using (Stream stream = fi.OpenRead())
//                    {
//                        string name = fi.Name;
//                        long numBytes = fi.Length;

//                        BinaryReader br = new BinaryReader(stream);

//                        var photo = br.ReadBytes((int)numBytes);
//                        var curr_patient_photo = SelectedItem.PatientPhoto.FirstOrDefault(p => p.HistoryKey == null);
//                        if (curr_patient_photo != null)
//                        {
//                            curr_patient_photo.BeginEditting();
//                            curr_patient_photo.Photo = photo;
//                        }
//                        else
//                        {
//                            var new_photo = new PatientPhoto
//                            {
//                                TenantID = SelectedItem.TenantID,
//                                Photo = photo,
//                                UpdatedBy = SelectedItem.UpdatedBy,
//                                UpdatedDate = SelectedItem.UpdatedDate
//                            };
//                            new_photo.BeginEditting();
//                            SelectedItem.PatientPhoto.Add(new_photo);
//                        }
//                    }
//                }
//            }
//        }
//#endif
//        public static readonly DependencyProperty ModelProperty =
//            DependencyProperty.Register("Model", typeof(IPatientService), typeof(PatientDetailUserControl), null);

//        public override bool HasChanges()
//        {
//            bool haschanges = _HasChangesOverride;

//            if (!haschanges)
//            {
//                if (SelectedItem.PatientPhoto.Any(p => p.HistoryKey == null))
//                {
//                    if (SelectedItem.PatientPhoto.First(p => p.HistoryKey == null).EntityState == EntityState.New)
//                    {
//                        haschanges = true;
//                    }
//                    else
//                    {
//                        haschanges = SelectedItem.PatientPhoto.First(p => p.HistoryKey == null).HasChanges;
//                    }
//                }
//            }

//            if (!haschanges)
//            {
//                haschanges = SelectedItem.PatientGenderExpression.Any(w => w.HasChanges || w.IsNew);
//            }

//            if (!haschanges)
//            {
//                haschanges = SelectedItem.PatientTranslator.Any(p => p.IsNew || p.HasChanges);
//            }

//            return haschanges;
//        }

//        public override System.Threading.Tasks.Task<bool> ValidateAsync()
//        {
//            return Model.ValidatePatientAsync(SelectedItem);
//        }

//        public override bool Validate()
//        {
//            bool AddedOverlap = false;

//            bool ret = true;
//            foreach (var item in SelectedItem.PatientTranslator)
//            {
//                item.ValidationErrors.Clear();

//                if (!item.Validate())
//                {
//                    ret = false;
//                }
//            }

//            foreach (var item in SelectedItem.PatientGenderExpression)
//            {
//                item.ValidationErrors.Clear();
//                if (!item.Validate())
//                {
//                    ret = false;
//                }
//                else
//                {
//                    if (!AddedOverlap)
//                    {
//                        var SameActiveDates = SelectedItem.PatientGenderExpression
//                            .Count(w => !w.Inactive && w.EffectiveFromDate == item.EffectiveFromDate);
//                        if (SameActiveDates > 1)
//                        {
//                            var e = new ValidationResult("Effective Date Overlap", new[] { "EffectiveFromDate", "PatientGenderExpressionTag" });
//                            item.ValidationErrors.Add(e);
//                            SelectedItem.ValidationErrors.Add(e);
//                            AddedOverlap = true;
//                            ret = false;
//                        }
//                    }
//                }
//            }

//            return ret;
//        }

//        private bool _HasChangesOverride;

//        public override void BeginEditting()
//        {
//            List<PatientGenderExpression> l = SelectedItem.PatientGenderExpression.ToList();
//            foreach (var e in l) e.BeginEditting();

//            RaisePropertyChanged("CanEditDeathDate");
//            var curr_patient_photo = SelectedItem.PatientPhoto.FirstOrDefault(p => p.HistoryKey == null);
//            if (curr_patient_photo != null)
//            {
//                curr_patient_photo.BeginEditting();
//            }

//            _HasChangesOverride = false;
//        }

//        public override void EndEditting()
//        {
//            List<PatientGenderExpression> l = SelectedItem.PatientGenderExpression.ToList();
//            foreach (var e in l) e.EndEditting();
//            PatientGenderExpressionCVSSetup();
//            RaisePropertyChanged("CanEditDeathDate");
//            RaisePropertyChanged("PatientGenderExpressionCVS");
//            PatientGenderExpressionCVS.Refresh();
//            var curr_patient_photo = SelectedItem.PatientPhoto.FirstOrDefault(p => p.HistoryKey == null);
//            if (curr_patient_photo != null)
//            {
//                curr_patient_photo.EndEditting();
//            }
//        }

//        public override void CancelEditting()
//        {
//            SelectedItem.ValidationErrors.Clear();

//            List<PatientGenderExpression> l = SelectedItem.PatientGenderExpression.ToList();
//            foreach (var e in l)
//            {
//                e.ValidationErrors.Clear();

//                if (e.IsNew)
//                {
//                    SelectedItem.PatientGenderExpression.Remove(e);
//                    Model.Remove(e);
//                }
//                else
//                {
//                    e.UndoChanges();

//                    if (e.IsEditting)
//                    {
//                        e.CancelEditting();
//                    }
//                }
//            }
            
//            RaisePropertyChanged("CanEditDeathDate");
//            RaisePropertyChanged("PatientGenderExpressionCVS");
//            PatientGenderExpressionCVS.Refresh();

//            var curr_patient_photo = SelectedItem.PatientPhoto.FirstOrDefault(p => p.HistoryKey == null);
//            if (curr_patient_photo != null)
//            {
//                curr_patient_photo.CancelEditting();
//            }
//        }

//        public override void RemoveFromModel()
//        {
//            List<PatientGenderExpression> l = SelectedItem.PatientGenderExpression.ToList();
//            foreach (var e in l)
//                if (e.IsNew)
//                {
//                    SelectedItem.PatientGenderExpression.Remove(e);
//                    Model.Remove(e);
//                }

//            PatientGenderExpressionCVSSetup();
//            var curr_patient_photo = SelectedItem.PatientPhoto.FirstOrDefault(p => p.HistoryKey == null);
//            if (curr_patient_photo != null)
//            {
//                if (curr_patient_photo.IsNew)
//                {
//                    SelectedItem.PatientPhoto.Remove(curr_patient_photo);
//                    Model.Remove(curr_patient_photo);
//                }
//            }

//            RaisePropertyChanged("PatientGenderExpressionCVS");
//            PatientGenderExpressionCVS.Refresh();
//        }

//        public override void RemoveFromModel(Patient entity)
//        {
//            if (Model == null)
//            {
//                throw new ArgumentNullException("Model", "Model is NULL");
//            }

//            if (Model.Items.Count() != 1) //only remove if NOT auto-add scenario
//            {
//                //NOTE: DetailUserControlBase will only call RemoveFromModel if (entity.EntityState == EntityState.New)
//                Model.Remove(entity);

//                //UI should enforce only allowing edits for a single parent entity and it's children entities at a time...
//                //Removing the current entity, so remove everything that might have been done during the current 
//                //edit session - e.g. toss everything, since we allow adding related data to new parent entities...
//                Model.RejectChanges();
//            }
//        }

//        public override void SaveModel(UserControlBaseCommandType command)
//        {
//            //Need to issue SAVE - regardless of whether command = OK or CANCEL...
//            //because there could be pending saves and the last user initiated action
//            //could have been a CANCEL.
//            if (Model == null)
//            {
//                throw new ArgumentNullException("Model", "Model is NULL");
//            }

//            //FYI: for now letting the view models handle Model.SaveAllAsync();
//        }
    }
}