<template>
  <div
    class="form-cbb"
    :class="{
      'border-red': isBorderRedFormCBB[propBorderRed],
    }"
  >
    <div class="e-textfield-cbb">
      <div class="container-input">
        <misa-input
          ref="InputFormCBB"
          :placeholder="placeholderInputFormCBB"
          :value="valueInput"
          @input="onSearchChange"
          :tabindex="tabindexFormCBB"
          @keydown="onKeyDownEntity"
          @mouseenter="isHoveringFormCBB = true"
          @mouseleave="isHoveringFormCBB = false"
        ></misa-input>
        <div
          class="misa-tooltip"
          v-if="
            isHoveringFormCBB &&
            isBorderRedFormCBB[propBorderRed] &&
            errorsFormCBB[propBorderRed]
          "
        >
          {{
            errorsFormCBB[propBorderRed]
              ? errorsFormCBB[propBorderRed]
              : errorsFormCBB[propBorderRed]
          }}
        </div>
      </div>
    </div>
    <div class="e-icon-cbb" @click="onShowSelectEntity">
      <div class="function-icon"></div>
    </div>
    <div
      class="form-cbb-menu"
      v-show="isShowSelectEntity"
      @click="onShowSelectEntity"
    >
      <div class="form-cbb-menu-title">
        <div>{{ this.textColFirst }}</div>
        <div>
          {{ this.textColSecond }}
        </div>
      </div>
      <div class="content-form">
        <template v-for="(item, index) in listEntitySearchFormCBB" :key="index">
          <div
            class="form-cbb-menu-item"
            @click="onSelectedEntity(item, index)"
            :class="[{ 'cbb-selected': index == indexEntitySelected }]"
            ref="EntitySelectedItem"
          >
            <div :class="`form-cbb-menu-item-${item.Grade}`">
              {{ item[propCode] }}
            </div>
            <div>{{ item[propName] }}</div>
          </div>
        </template>
      </div>
      <!-- <div
        class="form-cbb-menu-item"
        style="justify-content: center; position: relative"
      >
        <img
          class="form-cbb-loading"
          src="../../../assets/img/loading.svg"
          alt="loading"
        />
      </div> -->
    </div>
  </div>
</template>

<script>
export default {
  name: "MISAFormCombobox",

  props: [
    "propName",
    "propCode",
    "valueInput",
    "isBorderRedFormCBB",
    "entityFormCBB",
    "errorsFormCBB",
    "tabindexFormCBB",
    "listEntitySearchFormCBB",
    "placeholderInputFormCBB",
    "textColFirst",
    "textColSecond",
    "propBorderRed",
  ],

  data() {
    return {
      // Khai báo biến kiểm tra xem ô input có đang được hover hay không
      isHoveringFormCBB: false,
      // Khai báo biến quy định trạng thái hiển thị của combobox chọn đơn vị
      isShowSelectEntity: false,
      // Khai báo chỉ số đang được chọn trong combobox
      indexEntitySelected: 0,
    };
  },

  mounted() {
    this.$_MISAEmitter.on("focusInputFormCBB", () => {
      this.$refs["InputFormCBB"].focus();
    });
    this.$_MISAEmitter.on("closeMenuItemFormCBB", () => {
      this.isShowSelectEntity = false;
    });
  },

  methods: {
    /**
     * Mô tả: Hàm xử lí sự kiện ẩn hiện options chọn đơn vị
     * created by : BNTIEN
     * created date: 29-05-2023 07:54:42
     */
    onShowSelectEntity() {
      this.isShowSelectEntity = !this.isShowSelectEntity;
    },

    /**
     * Mô tả: Hàm xử lí sự kiện khi người dùng chọn đơn vị
     * created by : BNTIEN
     * created date: 29-05-2023 07:54:52`
     */
    onSelectedEntity(item, index) {
      this.$_MISAEmitter.emit("onSelectedEntityFormCBB", item);
      this.indexEntitySelected = index;
    },

    /**
     * Mô tả: Lắng nghe sự thay đổi text trong input search và tìm kiếm trong combobox
     * created by : BNTIEN
     * created date: 06-06-2023 22:31:16
     */
    async onSearchChange() {
      try {
        await this.$_MISAEmitter.emit(
          "onSearchChangeFormCBB",
          event.target.value
        );
        this.isShowSelectEntity = true;
      } catch {
        return;
      }
    },
  },

  beforeUnmount() {
    this.$_MISAEmitter.off("focusInputFormCBB");
    this.$_MISAEmitter.off("closeMenuItemFormCBB");
  },
};
</script>

<style scoped>
@import url(./MISAFormCombobox.css);

.select-entity-block {
  background-color: #fff;
  border: 1px solid var(--color-border-default);
  z-index: 100;
}

.e-textfield-cbb .textfield {
  border-radius: 4px 0px 0px 4px;
}

.cbb-selected {
  background-color: var(--color-btn-default);
  color: #ffffff;
}

.not-found-entity {
  text-align: center;
  opacity: 0.5;
}

.border-red {
  border: 1px solid red;
}
</style>
