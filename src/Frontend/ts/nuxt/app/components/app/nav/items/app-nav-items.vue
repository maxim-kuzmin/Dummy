<script setup lang="ts">
  import type { AppNavComponentItem } from '~/utils/domain/app/components/nav/app-nav-component.types'
  import type { AppNavItemComponentInput } from '~/utils/domain/app/components/nav/item/app-nav-item-component.types'
  import type { AppNavItemsComponentInput } from '~/utils/domain/app/components/nav/items/app-nav-items-component.types'

  const props = defineProps<AppNavItemsComponentInput>()

  const { items } = props

  function createItemComponentInput(
    item: AppNavComponentItem,
  ): AppNavItemComponentInput {
    return {
      item,
    }
  }
</script>

<template>
  <ul>
    <li
      v-for="item in items"
      :key="item.key"
      :data-selected="item.selected || null"
    >
      <AppNavItem v-bind="createItemComponentInput(item)" />
    </li>
  </ul>
</template>
