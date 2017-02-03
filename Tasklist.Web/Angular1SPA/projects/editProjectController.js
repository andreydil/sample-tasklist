(function () {
    'use strict';
    var controllerId = 'editProjectController';
    angular
        .module('app')
        .controller(controllerId, editProjectController);

    editProjectController.$inject = ['$location', '$routeParams', 'common', 'repository'];

    function editProjectController($location, $routeParams, common, repository) {
        var vm = this;
        var log = common.logger.getLogFn(controllerId);

        vm.id = -1;
        vm.name = '';
        vm.description = '';
        vm.tasks = [];
        vm.removeTask = function(task) {
            var index = vm.tasks.indexOf(task);
            vm.tasks.splice(index, 1);
        }
        vm.save = function () {
            var project = {
                id: vm.id,
                name: vm.name,
                description: vm.description,
                tasks: vm.tasks
            }
            repository.editProject(project).then(function () {
                $location.path('/');
            });
        }

        function getLastTask() {
            return vm.tasks[vm.tasks.length - 1];
        }

        vm.addEmptyTask = function () {
            var lastTask = getLastTask();
            if (!lastTask || lastTask.name) {
                vm.tasks.push({
                    name: '',
                    isDone: false
                });
            }
        }

        vm.delete = function () {
            repository.deleteProject(vm.id).then(function () {
                $location.path('/');
            });
        }

        activate();

        function activate() {
            common.activateController([getProject(), controllerId]).then(
                function () {
                    vm.addEmptyTask();
                });
        }

        function getProject() {
            var id = $routeParams.id;
            return repository.getProjectById(id).then(function (response) {
                var project = response.data;
                vm.id = project.id;
                vm.name = project.name;
                vm.description = project.description;
                vm.tasks = project.tasks;
            });
        }
    }
})();
