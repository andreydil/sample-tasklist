﻿(function () {
    'use strict';

    var app = angular.module('app');

    toastr.options.timeOut = 5000;
    toastr.options.positionClass = 'toast-bottom-right';


    var events = {
        controllerActivateSuccess: 'controller.activateSuccess',
        spinnerToggle: 'spinner.toggle'
    };

    var config = {
        appErrorPrefix: '[Error] ',
        docTitle: 'Task List: ',
        events: events,
        version: '1.0.0'
    };

    app.value('config', config);
    
    app.config(['$logProvider', function ($logProvider) {
        if ($logProvider.debugEnabled) {
            $logProvider.debugEnabled(true);
        }
    }]);
    
    app.config(['commonConfigProvider', function (cfg) {
        cfg.config.controllerActivateSuccessEvent = config.events.controllerActivateSuccess;
        cfg.config.spinnerToggleEvent = config.events.spinnerToggle;
    }]);
})();