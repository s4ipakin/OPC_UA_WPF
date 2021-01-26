using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workstation.ServiceModel.Ua;

namespace OpcUA_WPF
{
    [Subscription(endpointUrl: "opc.tcp://192.168.1.17:4840", publishingInterval: 500, keepAliveCount: 20)]
    public class MainViewModel  : SubscriptionBase
    {
        [MonitoredItem(nodeId: "ns=4;s=|var|WAGO 750-8202 PFC200 2ETH RS Tele T ECO.Application.HMI_Stepper.rFS_SetForce")]
        public float SetForce
        {
            get { return this.setForce; }
            set { this.SetProperty(ref this.setForce, value); }
        }

        private float setForce;

        [MonitoredItem(nodeId: "ns=4;s=|var|WAGO 750-8202 PFC200 2ETH RS Tele T ECO.Application.HMI_Stepper.xFS_Release")]
        public bool Release
        {
            get { return this.release; }
            set { this.SetProperty(ref this.release, value); }
        }

        private bool release;

        [MonitoredItem(nodeId: "ns=4;s=|var|WAGO 750-8202 PFC200 2ETH RS Tele T ECO.Application.HMI_Stepper.xFS_Start")]
        public bool Start
        {
            get { return this.start; }
            set { this.SetProperty(ref this.start, value); }
        }

        private bool start;

        [MonitoredItem(nodeId: "ns=4;s=|var|WAGO 750-8202 PFC200 2ETH RS Tele T ECO.Application.HMI_Stepper.wFS_ActualPos")]
        public long ActualPosition
        {
            get { return this.actualPosition; }
            set { this.SetProperty(ref this.actualPosition, value); }
        }

        private long actualPosition;

        [MonitoredItem(nodeId: "ns=4;s=|var|WAGO 750-8202 PFC200 2ETH RS Tele T ECO.Application.HMI_Stepper.wFS_RoughApprox")]
        public ushort RoughApprox
        {
            get { return this.roughApprox; }
            set { this.SetProperty(ref this.roughApprox, value); }
        }

        private ushort roughApprox;

        [MonitoredItem(nodeId: "ns=4;s=|var|WAGO 750-8202 PFC200 2ETH RS Tele T ECO.Application.HMI_Stepper.wFS_Step")]
        public ushort Step
        {
            get { return this.step; }
            set { this.SetProperty(ref this.step, value); }
        }

        private ushort step;

        [MonitoredItem(nodeId: "ns=4;s=|var|WAGO 750-8202 PFC200 2ETH RS Tele T ECO.Application.HMI_Stepper.rFS_Sensativity")]
        public float Sensativity
        {
            get { return this.sensativity; }
            set { this.SetProperty(ref this.sensativity, value); }
        }

        private float sensativity;

        [MonitoredItem(nodeId: "ns=4;s=|var|WAGO 750-8202 PFC200 2ETH RS Tele T ECO.Application.HMI_Stepper.wFS_SetSpeed")]
        public ushort SetSpeed
        {
            get { return this.setSpeed; }
            set { this.SetProperty(ref this.setSpeed, value); }
        }

        private ushort setSpeed;

        [MonitoredItem(nodeId: "ns=4;s=|var|WAGO 750-8202 PFC200 2ETH RS Tele T ECO.Application.HMI_Stepper.wFS_SetAcceleration")]
        public ushort SetAcceleration
        {
            get { return this.setAcceleration; }
            set { this.SetProperty(ref this.setAcceleration, value); }
        }

        private ushort setAcceleration;

        [MonitoredItem(nodeId: "ns=4;s=|var|WAGO 750-8202 PFC200 2ETH RS Tele T ECO.Application.HMI_Stepper.wFS_SetDeceleration")]
        public ushort SetDeceleration
        {
            get { return this.setDeceleration; }
            set { this.SetProperty(ref this.setDeceleration, value); }
        }

        private ushort setDeceleration;

        [MonitoredItem(nodeId: "ns=4;s=|var|WAGO 750-8202 PFC200 2ETH RS Tele T ECO.Application.HMI_Stepper.xFS_JogLeft")]
        public bool JogLeft
        {
            get { return this.jogLeft; }
            set { this.SetProperty(ref this.jogLeft, value); }
        }

        private bool jogLeft;

        [MonitoredItem(nodeId: "ns=4;s=|var|WAGO 750-8202 PFC200 2ETH RS Tele T ECO.Application.HMI_Stepper.xFS_JogRight")]
        public bool JogRight
        {
            get { return this.jogRight; }
            set { this.SetProperty(ref this.jogRight, value); }
        }

        private bool jogRight;

        [MonitoredItem(nodeId: "ns=4;s=|var|WAGO 750-8202 PFC200 2ETH RS Tele T ECO.Application.HMI_Stepper.wFS_State")]
        public ushort FS_State
        {
            get { return this.fS_State; }
            set { this.SetProperty(ref this.fS_State, value); }
        }

        private ushort fS_State;
    }
}
