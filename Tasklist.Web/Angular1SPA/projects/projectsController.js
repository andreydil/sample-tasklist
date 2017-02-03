(function () {
    'use strict';
    var controllerId = 'projectsController';
    angular
        .module('app')
        .controller(controllerId, projectsController);

    projectsController.$inject = ['$location', 'common', 'repository']; 

    function projectsController($location, common, repository) {
        var vm = this;
        var log = common.logger.getLogFn(controllerId);

        vm.projects = [];

        vm.edit = function(id) {
            $location.path('/editProject/' + id);
        };

        activate();

        function activate() {
            common.activateController([getProjects(), controllerId]);
        }

        function getProjects() {
            return repository.getAllProjects().then(function (response) {
                return vm.projects = response.data;
            });
        }
    }
})();
