﻿//import Vue from "../../../node_modules/vue/dist/vue";
import App from "../components/App.vue";

Vue.config.productionTip = false;

/* eslint-disable no-new */
new Vue({
    el: "#app",
    components: { App },
    template: "<App/>"
});
