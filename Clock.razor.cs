using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace BlazorApp2.Pages
{    
    public partial class Clock
    {
        [Parameter]
        public string Message { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        string currentTime = "N/A";
        string buttonAction = "N/A";
        string currentCss = "clock-notset";
        Timer timer;

        protected override void OnInitialized()
        {
            InitTimer();
            StartTimer();
        }

        private void StartStop()
        {
            if (timer.Enabled)
                StopTimer();
            else
                StartTimer();
        }

        private void StartTimer()
        {
            buttonAction = "STOP";
            timer.Start();
        }

        private void StopTimer()
        {
            buttonAction = "START";
            timer.Stop();
        }

        private void InitTimer()
        {
            timer = new Timer(1000);
            timer.Elapsed += async (sender, e) => await TimerTick();
        }

        private Task TimerTick()
        {
            currentTime = DateTime.Now.ToLongTimeString();
            currentCss = "clock-working";
            this.InvokeAsync(StateHasChanged);

            return Task.CompletedTask;
        }
    }
}
