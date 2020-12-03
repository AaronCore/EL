/*
 * http://supalle.gitee.io/sal/layout.html
 */
var api = {
    // 1.提示框
    showMsgByObj: function ({
        type,
        code,
        msg
    }) {
        // 传入对象提示消息
        this.showMsg(msg, type);
    },
    showMsg: function (msg, type) {
        // 传入参数显示消息
    },
    showMsgByHtml: function (title, html) {
        // 提示HTML内容
    },
    // 2.弹出窗
    // 3.子页面参数
    getTabParams: function (tabKey) {
        // 子页面的Key传进来
    },
    setTabParams: function (tabKey, params) {
        // 子页面的Key和params对象传进来
    },
    // 4.tabs操作
    jumpTabByObj: function ({
        id,
        title,
        url,
        icon
    }) {
        jumpTab(id, title, url, icon);
    },
    jumpTab: function (id, title, url, icon) {

    },
    tabCloseOrCallBack: function (tab, chain) {
        if (tab) {
            if (typeof chain === 'undefined') {
                // 传个空的防止出现 undefined
                chain = new SalChain([], null);
            }
            var cType = typeof tab.callback;
            if (cType === 'function') {
                tab.callback(tab, chain);
            } else {
                this.closeTab(tab);
                chain.next();
            }
        }
    },
    closeTab: function (tab) {

    },
    // 5.全屏loading遮罩
    openLoading: function (time) {
        // 打开遮罩,传入自动取消时间
    },
    closeLoading: function () {
        // 手动关闭遮罩
    },
    // 6.检查是否拥有资源，本质上是从menuArr中查找出来
    cr: function (key) {
        // Check Resource 的简写
    },
    getCurrTabRes: function (iframWindow) {
        // 获取当前tab页对应的资源
    }
};

var homeTab = {
    key: 'home',
    name: 'home',
    title: '',
    show: true,
    //url: 'aaa.html',
    icon: 'layui_icon font-size16 layui_icon_home',
    notClosable: true
};

