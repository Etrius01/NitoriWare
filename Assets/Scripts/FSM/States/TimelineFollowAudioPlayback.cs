﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Playables;

namespace StageFSM
{
    public class TimelineFollowAudioPlayback : StageStateMachineBehaviour
    {
        double dspStartTime;
        AudioSource audioSource;
        DirectorPlaybackController controller;

        protected override void OnStateEnterOfficial()
        {
            base.OnStateEnterOfficial();
            var playbackController = toolbox.GetTool<AudioPlaybackController>();
            controller = toolbox.GetTool<DirectorPlaybackController>();
            audioSource = playbackController.CurrentSource;
            dspStartTime = playbackController.LastScheduledAudioStartTime;
        }

        public override void OnStateUpdateOfficial()
        {
            base.OnStateUpdateOfficial();
            if (inStateOfficial)
            {
                var dspAudioTime = (AudioSettings.dspTime - dspStartTime) * Time.timeScale;
                if (dspAudioTime < 0d)
                    dspAudioTime = 0d;
                controller.time = dspAudioTime;
            }
        }
    }
}