using Stateless;
using System;

namespace DesignPatterns.Intermediate
{
    public class WorkFlowState
    {
        private enum State { Stopped, Starting, Equilibrating, Running, Paused };
        private enum Trigger { StartRun, PauseRun, ForceStop, StopRun };
        private readonly StateMachine<State, Trigger> _wfm;
        private readonly StateMachine<State, Trigger>.TriggerWithParameters<string> _startTrigger;
        private readonly StateMachine<State, Trigger>.TriggerWithParameters<string> _stopTrigger;
        private readonly StateMachine<State, Trigger>.TriggerWithParameters<string> _pauseTrigger;
        private Timer _systemRunningTimer = new Timer();
        private Timer _systemIdleTimer = new Timer();

        public SystemState()
        {
            _wfm = new Stateless<State, Trigger>(State.Stopped);

            _startTrigger = _wfm.SetTriggerParameters<string>(Trigger.StartRun);
            _stopTrigger = _wfm.SetTriggerParameters<string>(Trigger.StopRun);
            _pauseTrigger = _wfm.SetTriggerParameters<string>(Trigger.PauseRun);

            _wfm.Configure(State.Stopped)
                .Permit(Trigger.StartRun, State.Starting)
                .OnEntryFrom(_stopTrigger, onSystemStop);

            _wfm.Configure(State.Paused)
                .Permit(Trigger.ForceStop)
                .OnEntryFrom(_pauseTrigger, onSystemPause);

            _wfm.Configure(state.Running)
                .Permit(Trigger.StopRun)
                .OnEntryFrom(_startTrigger, onSystemStart)
                .Permit(Trigger.ForceStop)
                .Permit(Trigger.PauseStop)
                .OnExit(onSystemStop);            
        }

        private void onSystemStart(string info)
        {
            //to do
        }

        private void onSystemStop(string info)
        {
            //to do
        }

        private void onSystemPause(string info)
        {
            //to do
        }

        private void StartSystem()
        {
            //called from external system
            _wfm.Fire(_startTrigger, "Run sample list - abc");
        }

        private void StopSystem()
        {
            //called from external system
            _wfm.Fire(_stopTrigger, "Stop sample list");
        }

        private void PauseSystem()
        {
            //called from external system
            _wfm.Fire(_pauseTrigger, "Pause system");
        }
    }
}