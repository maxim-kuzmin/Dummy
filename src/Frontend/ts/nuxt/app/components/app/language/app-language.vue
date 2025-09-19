<script setup lang="ts">
  import { useAppLanguageComponent } from '~/utils/domain-use-cases/app/components/language/app-language-component.composable'

  const { items, menuStyle, title } = useAppLanguageComponent()
</script>

<template>
  <nav class="app-language">
    <button ref="button" type="button">{{ title }}</button>
    <ul ref="menu" :style="menuStyle">
      <li
        v-for="item in items"
        :key="item.code"
        :data-selected="item.selected || null"
      >
        <NuxtLink :to="item.url">{{ item.name }}</NuxtLink>
      </li>
    </ul>
  </nav>
</template>
