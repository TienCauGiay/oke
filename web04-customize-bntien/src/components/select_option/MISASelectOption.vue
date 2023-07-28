<template>
  <div style="position: relative">
    <div class="a-cbb" id="a-cbb">
      <input
        type="text"
        class="a-textfield-cbb"
        :class="{ noDisabled: !isDisabledMenu }"
        :value="itemSelected[propName]"
        readonly
      />
      <button
        :disabled="isDisabledMenu"
        class="a-icon-cbb"
        :class="{ noDisabled: !isDisabledMenu }"
        @click="this.isShowMenuSelect = !this.isShowMenuSelect"
      >
        <div class="function-icon"></div>
      </button>
    </div>
    <div class="col-md-l a-select-entity" v-if="isShowMenuSelect">
      <ul>
        <template v-for="(item, index) in listData" :key="index">
          <li
            @click="handleSelectItem(item, index)"
            :class="{ 'item-selected': index == indexSelected }"
          >
            {{ item[propName] }}
          </li>
        </template>
      </ul>
    </div>
  </div>
</template>

<script>
export default {
  name: "MISASelectOption",

  props: [
    "listData",
    "propName",
    "propCode",
    "isDisabledMenu",
    "valueSelected",
  ],

  created() {
    this.$_MISAEmitter.on("selectedDefaultItem", () => {
      this.itemSelected = this.listData[0];
    });
    this.$_MISAEmitter.on("unSelectedDefaultItem", () => {
      this.itemSelected = {};
    });
  },

  mounted() {
    this.itemSelected[this.propName] = this.valueSelected;
  },

  data() {
    return {
      // Biến quy định trạng thái hiển thị menu
      isShowMenuSelect: false,
      // Biến lưu item được chọn
      itemSelected: {},
      // Biến lưu vị trí được chọn
      indexSelected: 0,
    };
  },

  methods: {
    handleSelectItem(item, index) {
      this.itemSelected = item;
      this.indexSelected = index;
      this.isShowMenuSelect = false;
      this.$_MISAEmitter.emit(
        "onSelectedSelectOption",
        item[this.propCode],
        this.propCode.substring(0, this.propCode.length - 4)
      );
    },
  },

  beforeUnmount() {
    this.$_MISAEmitter.off("selectedDefaultItem");
    this.$_MISAEmitter.off("unSelectedDefaultItem");
  },
};
</script>

<style scoped>
@import url(./MISASelectOption.css);

.item-selected {
  background-color: var(--color-btn-default);
  color: #ffffff;
}

.item-selected:hover {
  background-color: var(--color-btn-default);
  color: #ffffff;
}

.noDisabled {
  background-color: #ffffff;
}

button.noDisabled:hover {
  background-color: var(--color-border-default);
}
</style>
