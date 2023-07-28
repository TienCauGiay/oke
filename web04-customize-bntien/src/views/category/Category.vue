<template>
  <div class="category-container">
    <div class="category-title">
      {{ this.$_MISAResource[this.$_LANG_CODE].CATEGORY.TITLE }}
    </div>
    <div class="category-content">
      <div class="category-row">
        <div class="category-md-4">
          <a class="title-menu-item">
            {{
              this.$_MISAResource[this.$_LANG_CODE].CATEGORY.TITLE_MEMU.OBJECTS
            }}
          </a>
          <a>
            {{
              this.$_MISAResource[this.$_LANG_CODE].CATEGORY.MENU_ITEM.CUSTOMER
            }}
          </a>
          <router-link to="/provider">
            {{
              this.$_MISAResource[this.$_LANG_CODE].CATEGORY.MENU_ITEM.PROVIDER
            }}
          </router-link>
          <router-link to="/employee">
            {{
              this.$_MISAResource[this.$_LANG_CODE].CATEGORY.MENU_ITEM.EMPLOYEE
            }}
          </router-link>
          <a>
            {{
              this.$_MISAResource[this.$_LANG_CODE].CATEGORY.MENU_ITEM
                .GROUP_CUSTOMER_PROVIDER
            }}
          </a>
        </div>
        <div class="category-md-4">
          <a class="title-menu-item">
            {{
              this.$_MISAResource[this.$_LANG_CODE].CATEGORY.TITLE_MEMU
                .SUPPLY_GOODS
            }}
          </a>
          <a>
            {{
              this.$_MISAResource[this.$_LANG_CODE].CATEGORY.MENU_ITEM
                .SUPPLY_GOODS
            }}
          </a>
          <a>
            {{
              this.$_MISAResource[this.$_LANG_CODE].CATEGORY.MENU_ITEM.WAREHOUSE
            }}
          </a>
          <a>
            {{
              this.$_MISAResource[this.$_LANG_CODE].CATEGORY.MENU_ITEM
                .GROUP_MATERIAL_GOOD_SERVICE
            }}
          </a>
          <a>
            {{ this.$_MISAResource[this.$_LANG_CODE].CATEGORY.MENU_ITEM.UNIT }}
          </a>
        </div>
        <div class="category-md-4">
          <a class="title-menu-item">
            {{
              this.$_MISAResource[this.$_LANG_CODE].CATEGORY.TITLE_MEMU.ACCOUNTS
            }}
          </a>
          <router-link to="/system-account">
            {{
              this.$_MISAResource[this.$_LANG_CODE].CATEGORY.MENU_ITEM
                .ACCOUNT_SYSTEM
            }}
          </router-link>
          <a>
            {{
              this.$_MISAResource[this.$_LANG_CODE].CATEGORY.MENU_ITEM
                .TRANFER_ACCOUNT
            }}
          </a>
          <a>
            {{
              this.$_MISAResource[this.$_LANG_CODE].CATEGORY.MENU_ITEM
                .ACCOUNT_DEFAULT
            }}
          </a>
        </div>
      </div>
      <div class="category-row">
        <div class="category-md-4">
          <a class="title-menu-item">
            {{
              this.$_MISAResource[this.$_LANG_CODE].CATEGORY.TITLE_MEMU.EXPENSE
            }}
          </a>
          <a>
            {{
              this.$_MISAResource[this.$_LANG_CODE].CATEGORY.MENU_ITEM
                .COSS_AGGREGATION_OBJECT
            }}
          </a>
          <a>
            {{
              this.$_MISAResource[this.$_LANG_CODE].CATEGORY.MENU_ITEM
                .EXPENSE_ITEM
            }}
          </a>
          <a>
            {{
              this.$_MISAResource[this.$_LANG_CODE].CATEGORY.MENU_ITEM
                .CONSTRUCTION
            }}
          </a>
          <a>
            {{
              this.$_MISAResource[this.$_LANG_CODE].CATEGORY.MENU_ITEM
                .TYPE_CONSTRUCTION
            }}
          </a>
        </div>
        <div class="category-md-4">
          <a class="title-menu-item">
            {{
              this.$_MISAResource[this.$_LANG_CODE].CATEGORY.TITLE_MEMU.BANKS
            }}
          </a>
          <a>
            {{ this.$_MISAResource[this.$_LANG_CODE].CATEGORY.MENU_ITEM.BANK }}
          </a>
          <a>
            {{
              this.$_MISAResource[this.$_LANG_CODE].CATEGORY.MENU_ITEM
                .BANK_ACCOUNT
            }}
          </a>
        </div>
        <div class="category-md-4">
          <a class="title-menu-item">
            {{
              this.$_MISAResource[this.$_LANG_CODE].CATEGORY.TITLE_MEMU
                .BRANCH_DEPARTMENT
            }}
          </a>
          <a>
            {{
              this.$_MISAResource[this.$_LANG_CODE].CATEGORY.MENU_ITEM
                .ORGANIZATIONAL_STRUCTURE
            }}
          </a>
        </div>
      </div>
      <div class="category-row">
        <div class="category-md-4">
          <a class="title-menu-item">
            {{
              this.$_MISAResource[this.$_LANG_CODE].CATEGORY.TITLE_MEMU.ASSETS
            }}
          </a>
          <a>
            {{
              this.$_MISAResource[this.$_LANG_CODE].CATEGORY.MENU_ITEM.TYPE_TOOL
            }}
          </a>
          <a>
            {{
              this.$_MISAResource[this.$_LANG_CODE].CATEGORY.MENU_ITEM
                .TYPE_ASSETS
            }}
          </a>
        </div>
        <div class="category-md-4">
          <a class="title-menu-item">
            {{ this.$_MISAResource[this.$_LANG_CODE].CATEGORY.TITLE_MEMU.TAX }}
          </a>
          <a>
            {{
              this.$_MISAResource[this.$_LANG_CODE].CATEGORY.MENU_ITEM
                .SPECIAL_CONSUMPTION_TARIFF
            }}
          </a>
          <a>
            {{
              this.$_MISAResource[this.$_LANG_CODE].CATEGORY.MENU_ITEM
                .RESOURCE_TAX_SCHEDULE
            }}
          </a>
        </div>
        <div class="category-md-4">
          <a class="title-menu-item">
            {{
              this.$_MISAResource[this.$_LANG_CODE].CATEGORY.TITLE_MEMU.OTHER
            }}
          </a>
          <a>
            {{
              this.$_MISAResource[this.$_LANG_CODE].CATEGORY.MENU_ITEM
                .TERM_PAYMENT
            }}
          </a>
          <a>
            {{
              this.$_MISAResource[this.$_LANG_CODE].CATEGORY.MENU_ITEM
                .REVENUE_DISBURSEMENT
            }}
          </a>
          <a>
            {{
              this.$_MISAResource[this.$_LANG_CODE].CATEGORY.MENU_ITEM
                .STATISTICAL_CODE
            }}
          </a>
          <a>
            {{
              this.$_MISAResource[this.$_LANG_CODE].CATEGORY.MENU_ITEM
                .TYPE_MONEY
            }}
          </a>
          <a>
            {{
              this.$_MISAResource[this.$_LANG_CODE].CATEGORY.MENU_ITEM
                .TYPE_DOCUMENT
            }}
          </a>
        </div>
      </div>
      <div class="category-row">
        <div class="category-md-4">
          <a class="title-menu-item">
            {{
              this.$_MISAResource[this.$_LANG_CODE].CATEGORY.TITLE_MEMU.SALARY
            }}
          </a>
          <a>
            {{
              this.$_MISAResource[this.$_LANG_CODE].CATEGORY.MENU_ITEM
                .TIME_ATTENDANCE_SYMBOL
            }}
          </a>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "CategoryPage",
};
</script>

<style>
@import url(./Category.css);
</style>
