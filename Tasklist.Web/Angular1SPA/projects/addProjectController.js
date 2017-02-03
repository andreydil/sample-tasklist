(function () {
    'use strict';
    var controllerId = 'addProjectController';
    angular
        .module('app')
        .controller(controllerId, addProjectController);

    addProjectController.$inject = ['$location', 'common', 'repository'];

    function addProjectController($location, common, repository) {
        var vm = this;
        var log = common.logger.getLogFn(controllerId);

        vm.name = '';
        vm.description = '';

        vm.addProject = function () {
            repository.addProject(vm.name, vm.description).then(function (response) {
                $location.path('/editProject/' + response.data);
            });
        }

        activate();

        function activate() {
            common.activateController([controllerId]);
        }
    }
})();
