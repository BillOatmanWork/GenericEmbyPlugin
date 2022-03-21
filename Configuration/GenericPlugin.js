define(["loading", "dialogHelper", "formDialogStyle", "emby-checkbox", "emby-select", "emby-toggle"],
    function(loading, dialogHelper) {

        var pluginId = "1024CC72-802F-4EFB-89FB-F190AFF12345";

        return function(view) {
            view.addEventListener('viewshow',
                async () => {
                    var chkEnableDisable = view.querySelector('#enableDisable');

                    ApiClient.getPluginConfiguration(pluginId).then((config) => {
                        chkEnableDisable.checked = config.EnableGenericPlugin ?? false;
                    });

                    chkEnableDisable.addEventListener('change', (elem) => {
                        elem.preventDefault();
                        var autoSkip = chkEnableDisable.checked;
                        enableAutoSkip(autoSkip);
                    });

                    function enableAutoSkip(value) {
                        ApiClient.getPluginConfiguration(pluginId).then((config) => {
                            config.EnableGenericPlugin = value;
                            ApiClient.updatePluginConfiguration(pluginId, config).then(() => {});
                        });
                    }
                });
        }
    });