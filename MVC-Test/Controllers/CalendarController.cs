using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DHTMLX.Scheduler;
using DHTMLX.Common;
using DHTMLX.Scheduler.Data;
using DHTMLX.Scheduler.Controls;

using MVC_Test.Models;
using MVC_Test.DAL;

namespace MVC_Test.Controllers
{
    public class CalendarController : Controller
    {
        public ActionResult Index()
        {
            //Being initialized in that way,  
            var scheduler = new DHXScheduler(this);
            //scheduler.Skin = DHXScheduler.Skins.Terrace;
       

            // blocks entry fields in the 'Time period' section 
            //of the lightbox and sets time period to a full day  
            scheduler.Config.full_day = true;

            scheduler.Skin = DHXScheduler.Skins.Material;
            scheduler.Extensions.Add(SchedulerExtensions.Extension.QuickInfo);
            scheduler.Config.separate_short_events = true;
           //
           // scheduler.Extensions.Add(SchedulerExtensions.Extension.ActiveLinks);

            var data = new SchedulerAjaxData(new CloudbassContext().Schedules);

            scheduler.LoadData = true;
            scheduler.EnableDataprocessor = true;

            return View(scheduler);
        }

       // scheduler will use CalendarController.Data as a the datasource
        public ContentResult Data()
        {
            //THIS ALLOW TO RENDER DATA FROM THE TABLE TO THE VIEW PAGE WHEN BROWSER LOAD
            var data = new SchedulerAjaxData(
               new CloudbassContext().Schedules
               .Select(sc => new { sc.Id, sc.text, sc.start_date, sc.end_date /*, sc.JobId, sc.SchType*/ })
                );

            return data;

            //var data = new SchedulerAjaxData(new CloudbassContext().Schedules);
            //var data = new SchedulerAjaxData(data.schedules);
            //return data;

            //var data = new SchedulerAjaxData(
            //   new CloudbassContext().Schedules);
            //return (ContentResult)data;
        }


        // and CalendarController.Save to process changes
        public ContentResult Save(int? id, FormCollection actionValues)
        {
            var action = new DataAction(actionValues);

            try
            {
                var changedEvent = (Schedule)DHXEventsHelper.Bind(typeof(Schedule), actionValues);

                var data = new CloudbassContext();

                switch (action.Type)
                {
                    case DataActionTypes.Insert:
                        //do insert
                        //if (data.Schedules.Add(changedEvent))
                        //{
                        //    action.Type = DataActionTypes.Error;
                        //}

                        data.Schedules.Add(changedEvent);
                         // action.TargetId = changedEvent.Id;//assign postoperational id
                        break;

                    case DataActionTypes.Delete:
                        //do delete

                        changedEvent = data.Schedules.FirstOrDefault(sc => sc.Id == action.SourceId);
                        data.Schedules.Remove(changedEvent);

                        break;
                    default:// "update"                          
                        var eventToUpdate = data.Schedules.FirstOrDefault(sc => sc.Id == action.SourceId);
                        DHXEventsHelper.Update(eventToUpdate, changedEvent, new List<string>() { "Id" });
                        break;
                }

                data.SaveChanges();
                action.TargetId = changedEvent.Id;
            }
            catch
            {
                action.Type = DataActionTypes.Error;
            }
            return new AjaxSaveResponse(action);
        }
    }
}

