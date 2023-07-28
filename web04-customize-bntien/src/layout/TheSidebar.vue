<template>
  <div id="sidebar" class="sidebar">
    <div class="sidebar-logo">
      <div class="icon-tb toggle toggle-icon"></div>
      <div class="logo-icon icon-l"></div>
      <span>{{
        this.$_MISAResource[this.$_LANG_CODE].TEXT_CONTENT.ACCOUNTANT
      }}</span>
    </div>
    <div class="menu">
      <ul class="nav">
        <li class="menu-item">
          <a class="menu-item-a">
            <i class="icon-tb overview-icon"></i>
            <span>{{
              this.$_MISAResource[this.$_LANG_CODE].TEXT_CONTENT.ITEM_SIDEBAR
                .OVERVIEW
            }}</span>
          </a>
        </li>
        <li class="menu-item">
          <a class="menu-item-a">
            <i class="icon-tb cash-icon"></i>
            <span>{{
              this.$_MISAResource[this.$_LANG_CODE].TEXT_CONTENT.ITEM_SIDEBAR
                .CASH
            }}</span>
          </a>
        </li>
        <li class="menu-item">
          <a class="menu-item-a">
            <i class="icon-tb deposits-icon"></i>
            <span>{{
              this.$_MISAResource[this.$_LANG_CODE].TEXT_CONTENT.ITEM_SIDEBAR
                .DEPOSITS
            }}</span>
          </a>
        </li>
        <li class="menu-item">
          <a class="menu-item-a">
            <i class="icon-tb bag-icon"></i>
            <span>{{
              this.$_MISAResource[this.$_LANG_CODE].TEXT_CONTENT.ITEM_SIDEBAR
                .BAG
            }}</span>
          </a>
        </li>
        <li class="menu-item">
          <a class="menu-item-a">
            <i class="icon-tb cart-icon"></i>
            <span>{{
              this.$_MISAResource[this.$_LANG_CODE].TEXT_CONTENT.ITEM_SIDEBAR
                .CART
            }}</span>
          </a>
        </li>
        <li class="menu-item">
          <a class="menu-item-a">
            <i class="icon-tb bill-icon"></i>
            <span>{{
              this.$_MISAResource[this.$_LANG_CODE].TEXT_CONTENT.ITEM_SIDEBAR
                .BILL
            }}</span>
          </a>
        </li>
        <li class="menu-item">
          <a class="menu-item-a">
            <i class="icon-tb warehouse-icon"></i>
            <span>{{
              this.$_MISAResource[this.$_LANG_CODE].TEXT_CONTENT.ITEM_SIDEBAR
                .WAREHOUSE
            }}</span>
          </a>
        </li>
        <li class="menu-item">
          <a class="menu-item-a">
            <i class="icon-tb tool-icon"></i>
            <span>{{
              this.$_MISAResource[this.$_LANG_CODE].TEXT_CONTENT.ITEM_SIDEBAR
                .TOOL
            }}</span>
          </a>
        </li>
        <li class="menu-item">
          <a class="menu-item-a">
            <i class="icon-tb asset-icon"></i>
            <span>{{
              this.$_MISAResource[this.$_LANG_CODE].TEXT_CONTENT.ITEM_SIDEBAR
                .ASSET
            }}</span>
          </a>
        </li>
        <li class="menu-item">
          <a class="menu-item-a">
            <i class="icon-tb tax-icon"></i>
            <span>{{
              this.$_MISAResource[this.$_LANG_CODE].TEXT_CONTENT.ITEM_SIDEBAR
                .TAX
            }}</span>
          </a>
        </li>
        <li class="menu-item">
          <a class="menu-item-a">
            <i class="icon-tb price-icon"></i>
            <span>{{
              this.$_MISAResource[this.$_LANG_CODE].TEXT_CONTENT.ITEM_SIDEBAR
                .PRICE
            }}</span>
          </a>
        </li>
        <li class="menu-item">
          <a class="menu-item-a">
            <i class="icon-tb synthetic-icon"></i>
            <span>{{
              this.$_MISAResource[this.$_LANG_CODE].TEXT_CONTENT.ITEM_SIDEBAR
                .SYNTHETIC
            }}</span>
          </a>
        </li>
        <li class="menu-item">
          <a class="menu-item-a">
            <i class="icon-tb budget-icon"></i>
            <span>{{
              this.$_MISAResource[this.$_LANG_CODE].TEXT_CONTENT.ITEM_SIDEBAR
                .BUDGET
            }}</span>
          </a>
        </li>
        <li class="menu-item">
          <a class="menu-item-a">
            <i class="icon-tb report-icon"></i>
            <span>{{
              this.$_MISAResource[this.$_LANG_CODE].TEXT_CONTENT.ITEM_SIDEBAR
                .REPORT
            }}</span>
          </a>
        </li>
        <!-- <li class="menu-item">
          <router-link to="/" class="menu-item-a">
            <i class="icon-tb finance-icon"></i>
            <span>{{ this.$_MISAResource[this.$_LANG_CODE].TEXT_CONTENT.ITEM_SIDEBAR.FINANCE }}</span>
          </router-link>
        </li> -->
        <div style="border-top: 1px solid white"></div>
        <li class="menu-item">
          <router-link to="/category" class="menu-item-a">
            <i class="icon-tb category-icon"></i>
            <span>{{
              this.$_MISAResource[this.$_LANG_CODE].TEXT_CONTENT.ITEM_SIDEBAR
                .CATEGORY
            }}</span>
          </router-link>
        </li>
        <!-- <li class="menu-item">
          <a class="menu-item-a">
            <i class="icon-tb setting-icon" style="scale: 0.85 0.85"></i>
            <span>{{
              this.$_MISAResource[this.$_LANG_CODE].TEXT_CONTENT.ITEM_SIDEBAR
                .INITIAL_BLANCE
            }}</span>
          </a>
        </li> -->
        <li class="menu-item">
          <a class="menu-item-a">
            <i class="icon-tb knowledge-icon"></i>
            <span>{{
              this.$_MISAResource[this.$_LANG_CODE].TEXT_CONTENT.ITEM_SIDEBAR
                .ANTS
            }}</span>
          </a>
        </li>
      </ul>
    </div>
  </div>
</template>

<script>
export default {
  name: "TheSidebar",
};
</script>

<style>
@import url(@/css/sidebar.css);
</style>
